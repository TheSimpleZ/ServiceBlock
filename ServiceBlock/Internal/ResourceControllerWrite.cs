#nullable enable
using System;
using System.Threading.Tasks;
using ServiceBlock.Interface.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceBlock.Interface.Resource;
using System.Security.Claims;

namespace ServiceBlock.Internal
{
    class ResourceControllerWrite<T> : ResourceControllerRead<T> where T : AbstractResource
    {


        private readonly ILogger<ResourceControllerWrite<T>> _logger;
        private readonly Storage<T> _storage;


        public ResourceControllerWrite(ILogger<ResourceControllerWrite<T>> logger, Storage<T> storage) : base(logger, storage)
        {
            _logger = logger;
            _storage = storage;

            logger.LogDebug("Write controller for resource {ResourceType} initialized.", typeof(T).Name);

        }

        [HttpPost]
        public async Task<ActionResult<T>> Post([FromBody]T resource)
        {
            var apa = User.FindFirst(ClaimTypes.GivenName)?.Value;
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
