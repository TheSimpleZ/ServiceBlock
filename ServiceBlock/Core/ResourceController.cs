#nullable enable
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceBlock.Interface;
using ServiceBlock.Interface.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceBlock.Interface.Resource;

namespace ServiceBlock.Core
{
    class ResourceController<T> : ControllerBase where T : AbstractResource
    {


        private readonly ILogger<ResourceController<T>> _logger;
        private readonly Storage<T> _storage;


        public ResourceController(ILogger<ResourceController<T>> logger, Storage<T>? storage)
        {
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
                return Ok(await _storage.Read());
            });
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<T>> Get([FromRoute] Guid Id)
        {
            return await HandleRequest<T>(async () => Ok(await _storage.Read(Id)));
        }

        [HttpPost]
        public async Task<ActionResult<T>> Post([FromBody]T resource)
        {
            return await HandleRequest<T>(async () => Ok(await _storage.Create(resource)));
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<T>> Put([FromRoute]Guid Id, [FromBody]T resource)
        {
            return await HandleRequest<T>(async () => Ok(await _storage.Update(resource)));
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<T>> Delete([FromRoute]Guid Id)
        {
            return await HandleRequest<T>(async () =>
            {
                await _storage.Delete(Id);
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
