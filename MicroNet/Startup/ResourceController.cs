using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroNet.Interface;
using MicroNet.Interface.Storage;
using MicroNet.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroNet.Startup
{
    // [ApiController]
    // [Route("[controller]")]
    public class ResourceController<T> : ControllerBase where T : IResource
    {


        private readonly ILogger<ResourceController<T>> _logger;
        private readonly IStorage<T> _storage;

        private readonly IResourceEventListener<T> _transformer;

        public ResourceController(ILogger<ResourceController<T>> logger, IStorage<T> storage = null, IResourceEventListener<T> transformer = null)
        {
            _transformer = transformer;
            _logger = logger;

            if (storage == null)
            {
                throw new NoStorageException($"The resource {typeof(T).Name} does not have a storage associated with it.");
            }

            _storage = storage;


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            return await HandleRequest<IEnumerable<T>>(async () =>
            {
                var resources = await _storage.Get();

                if (_transformer != null)
                    return Ok(await _transformer.OnGet(resources));
                return Ok(resources);
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get([FromRoute]Guid Id)
        {
            return await HandleRequest<T>(async () =>
            {
                var resource = await _storage.Get(Id);

                if (_transformer != null)
                    return await _transformer.OnGet(resource);

                return resource;
            });
        }

        [HttpPost]
        public async Task<ActionResult<T>> Post([FromBody]T resource)
        {
            return await HandleRequest<T>(async () =>
            {
                var transformed = resource;

                if (_transformer != null)
                    transformed = await _transformer?.OnCreate(resource);

                return Ok(await _storage.Create(transformed));
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Put([FromRoute]Guid Id, [FromBody]T resource)
        {
            return await HandleRequest<T>(async () =>
            {
                var transformed = resource;

                if (_transformer != null)
                    transformed = await _transformer.OnReplace(transformed);

                return Ok(await _storage.Replace(transformed));
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<T>> Delete([FromRoute]Guid Id)
        {
            return await HandleRequest<T>(async () =>
            {
                await _transformer?.OnDelete(Id);
                await _storage.Delete(Id);
                return Ok();
            });
        }

        public async Task<ActionResult<TT>> HandleRequest<TT>(Func<Task<ActionResult<TT>>> onRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await onRequest();
        }

    }
}
