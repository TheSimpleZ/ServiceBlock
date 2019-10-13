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
    class ResourceController<T> : ReadOnlyResourceController<T> where T : AbstractResource
    {


        private readonly ILogger<ResourceController<T>> _logger;
        private readonly Storage<T> _storage;


        public ResourceController(ILogger<ResourceController<T>> logger, Storage<T>? storage) : base(logger, storage)
        {
            _logger = logger;

            if (storage == null)
            {
                throw new NoStorageException($"The resource {typeof(T).Name} does not have a compatible storage associated with it.");
            }

            _storage = storage;

            logger.LogDebug("Controller for resource {ResourceType} initialized.", typeof(T).Name);

        }

        [HttpPost]
        public async Task<ActionResult<T>> Post([FromBody]T resource)
        {
            return await HandleRequest<T>(async () =>
            {
                var createdResource = await _storage.Create(resource);
                return CreatedAtAction(nameof(Get), new { id = createdResource.Id }, createdResource);
            });
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

    }
}
