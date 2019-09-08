using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroNet.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroNet.Startup
{
    [ApiController]
    [Route("[controller]")]
    public class ResourceController<T> : ControllerBase
    {


        private readonly ILogger<ResourceController<T>> _logger;
        private readonly IStorage<T> _storage;

        private readonly IResourceEventListener<T> _transformer;

        public ResourceController(ILogger<ResourceController<T>> logger, IStorage<T> storage, IResourceEventListener<T> transformer = null)
        {
            _transformer = transformer;
            _logger = logger;
            _storage = storage;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            var resources = await _storage.Get();

            if (_transformer != null)
                return Ok(await _transformer.OnGet(resources));

            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<T>>> Get(Guid Id)
        {
            var resource = await _storage.Get(Id);

            if (_transformer != null)
                return Ok(await _transformer.OnGet(resource));

            return Ok(resource);
        }

        [HttpPost]
        public async Task<ActionResult<T>> Post(T resource)
        {
            var transformed = resource;

            if (_transformer != null)
                transformed = await _transformer?.OnCreate(resource);

            return Ok(await _storage.Create(transformed));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Put(Guid Id, T resource)
        {
            var transformed = await _transformer?.OnReplace(resource) ?? resource;
            return Ok(await _storage.Replace(transformed));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<T>> Delete(Guid Id)
        {
            await _transformer?.OnDelete(Id);
            await _storage.Delete(Id);
            return Ok();
        }
    }
}
