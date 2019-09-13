using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;


namespace MicroNet.Interface.Storage
{
    public class MemoryStorage<T> : IStorage<T> where T : IResource
    {
        private Dictionary<Guid, T> storage = new Dictionary<Guid, T>();
        private readonly ILogger<MemoryStorage<T>> _logger;

        public MemoryStorage(ILogger<MemoryStorage<T>> logger)
        {
            this._logger = logger;
            logger.LogInformation("Memory storage initialized");
        }


        public Task<IEnumerable<T>> Get()
        {
            return Task.FromResult(storage.Values.AsEnumerable());
        }

        public Task<T> Get(Guid Id)
        {

            var resource = storage.SingleOrDefault(x => x.Key == Id).Value;

            if (resource == null)
                throw new NotFoundException($"Could not find {typeof(T).Name} with ID {Id}");

            return Task.FromResult(resource);
        }

        public Task<T> Create(T resource)
        {
            this.storage.Add(resource.Id, resource);
            return Task.FromResult(resource);
        }

        public Task Delete(Guid Id)
        {
            this.storage.Remove(Id);
            return Task.CompletedTask;
        }


        public Task<T> Replace(T resource)
        {
            if (storage[resource.Id] == null)
                throw new NotFoundException();

            storage[resource.Id] = resource;
            return Task.FromResult(resource);
        }
    }
}