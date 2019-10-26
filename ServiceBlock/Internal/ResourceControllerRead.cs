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
using System.Linq;
using ServiceBlock.Extensions;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using Newtonsoft.Json;

namespace ServiceBlock.Internal
{
    class ResourceControllerRead<T> : ControllerBase where T : AbstractResource
    {


        private readonly ILogger<ResourceControllerRead<T>> _logger;
        private readonly Storage<T> _storage;

        private readonly IEnumerable<string> queryStringParameterNames = AbstractResource.GetQueryableProperties(typeof(T)).Select(q => q.Name);


        public ResourceControllerRead(ILogger<ResourceControllerRead<T>> logger, Storage<T> storage)
        {
            _logger = logger;
            _storage = storage;

            logger.LogDebug("Read controller for resource {ResourceType} initialized.", typeof(T).Name);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            return await HandleRequest<IEnumerable<T>>(async () =>
            {
                var query = HttpContext.Request.Query;

                var queryParams = query.Where(kv => queryStringParameterNames.Contains(kv.Key)).ToDictionary(kv => kv.Key, kv => (string)kv.Value);

                return Ok(await _storage.Read(queryParams));
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
