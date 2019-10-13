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
    class ReadOnlyResourceController<T> : ControllerBase where T : AbstractResource
    {


        private readonly ILogger<ReadOnlyResourceController<T>> _logger;
        private readonly Storage<T> _storage;


        public ReadOnlyResourceController(ILogger<ReadOnlyResourceController<T>> logger, Storage<T>? storage)
        {
            _logger = logger;

            if (storage == null)
            {
                throw new NoStorageException($"The resource {typeof(T).Name} does not have a compatible storage associated with it.");
            }

            _storage = storage;

            logger.LogDebug("Read only controller for resource {ResourceType} initialized.", typeof(T).Name);

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

        protected async Task<ActionResult<TT>> HandleRequest<TT>(Func<Task<ActionResult<TT>>> onRequest)
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
