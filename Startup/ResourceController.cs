using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Startup.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class ResourceController<T> : ControllerBase
    {


        private readonly ILogger<ResourceController<T>> _logger;
        private readonly IStorage<T> _storage;

        private readonly ITransformer<T> _transformer;

        public ResourceController(ILogger<ResourceController<T>> logger, IStorage<T> storage, ITransformer<T> transformer = null)
        {
            this._transformer = transformer;
            _logger = logger;
            this._storage = storage;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            var resources = await this._storage.Get();

            if (this._transformer != null)
                return Ok(await this._transformer.OnGet(resources));

            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<T>>> Get(Guid Id)
        {
            var resource = await this._storage.Get(Id);

            if (this._transformer != null)
                return Ok(await this._transformer.OnGet(resource));

            return Ok(resource);
        }

        [HttpPost]
        public async Task<ActionResult<T>> Post(T resource)
        {
            var transformed = await this._transformer?.OnCreate(resource) ?? resource;
            return Ok(await this._storage.Create(transformed));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Put(Guid Id, T resource)
        {
            var transformed = await this._transformer?.OnReplace(resource) ?? resource;
            return Ok(await this._storage.Replace(transformed));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<T>> Delete(Guid Id)
        {
            await this._transformer?.OnDelete(Id);

            return Ok(await this._storage.Delete(Id));
        }
    }
}
