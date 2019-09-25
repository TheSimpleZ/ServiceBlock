#nullable enable
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceBlock.Interface;
using ServiceBlock.Interface.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceBlock.Interface.Resource;
using Microsoft.AspNetCore.Authorization;
using ServiceBlock.Messaging;
using ServiceBlock.Extensions;

namespace ServiceBlock.Core
{
    class ResourceController<T> : ControllerBase where T : AbstractResource
    {


        private readonly ILogger<ResourceController<T>> _logger;
        private readonly IStorage<T> _storage;

        private readonly ResourceTransformer<T>? _transformer;
        private readonly ResourceEventService? _eventService;

        private bool _shouldPublishEvent(ResourceEventType type) => _eventService != null
                                                                     && typeof(T).GetAttributeValue((EmitEventsAttribute attr) => attr.EventTypes).Contains(type);

        public ResourceController(ILogger<ResourceController<T>> logger, IStorage<T>? storage = null, ResourceTransformer<T>? transformer = null, ResourceEventService? eventService = null)
        {
            _transformer = transformer;
            this._eventService = eventService;
            _logger = logger;

            if (storage == null)
            {
                throw new NoStorageException($"The resource {typeof(T).Name} does not have a compatible storage associated with it.");
            }

            _storage = storage;


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            return await HandleRequest<IEnumerable<T>>(async () =>
            {
                var resources = await _storage.Read();

                if (_transformer != null)
                    return Ok(await _transformer.OnGet(resources));
                return Ok(resources);
            });
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<T>> Get([FromRoute] Guid Id)
        {
            return await HandleRequest<T>(async () =>
            {
                var resource = await _storage.Read(Id);

                if (_transformer != null)
                    return Ok(await _transformer.OnGet(resource));

                return Ok(resource);
            });
        }

        [HttpPost]
        public async Task<ActionResult<T>> Post([FromBody]T resource)
        {
            return await HandleRequest<T>(async () =>
            {
                var transformed = resource;

                if (_transformer != null)
                    transformed = await _transformer.OnCreate(resource);

                var created = await _storage.Create(transformed);

                if (_shouldPublishEvent(ResourceEventType.Created))
                {
                    await _eventService!.Publish(ResourceEventType.Created, created);
                }


                return Ok(created);
            });
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<T>> Put([FromRoute]Guid Id, [FromBody]T resource)
        {
            return await HandleRequest<T>(async () =>
            {
                var transformed = resource;

                if (_transformer != null)
                    transformed = await _transformer.OnReplace(transformed);

                var updated = await _storage.Update(transformed);

                if (_shouldPublishEvent(ResourceEventType.Updated))
                {
                    await _eventService!.Publish(ResourceEventType.Updated, updated);
                }


                return Ok(updated);
            });
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<T>> Delete([FromRoute]Guid Id)
        {
            return await HandleRequest<T>(async () =>
            {

                if (_shouldPublishEvent(ResourceEventType.Deleted))
                {
                    var resource = await _storage.Read(Id);

                    if (_transformer != null)
                        await _transformer.OnDelete(Id);

                    await _storage.Delete(Id);

                    await _eventService!.Publish(ResourceEventType.Deleted, resource);
                }
                else
                {
                    if (_transformer != null)
                        await _transformer.OnDelete(Id);

                    await _storage.Delete(Id);
                }

                return Ok();
            });
        }

        private async Task<ActionResult<TT>> HandleRequest<TT>(Func<Task<ActionResult<TT>>> onRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return await onRequest();
            }
            catch (NotImplementedException e)
            {
                _logger.LogError(e, "Method not implemented");
                return StatusCode(StatusCodes.Status501NotImplemented);
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e, "Resource not found");
                return NotFound();
            }
        }

    }
}
