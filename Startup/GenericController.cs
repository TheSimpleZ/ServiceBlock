using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Startup.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenericController<T> : ControllerBase
    {


        private readonly ILogger<GenericController<T>> _logger;
        private readonly IStorage<T> _storage;

        public GenericController(ILogger<GenericController<T>> logger, IStorage<T> storage)
        {
            _logger = logger;
            this._storage = storage;
        }

        [HttpGet]
        public IEnumerable<T> Get()
        {
            return this._storage.Get();
        }
    }
}
