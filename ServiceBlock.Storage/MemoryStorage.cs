using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface;
using ServiceBlock.Interface.Storage;

namespace ServiceBlock.Storage
{
    public class MemoryStorage<T> : IStorage<T> where T : AbstractResource
    {
        private Dictionary<Guid, T> storage = new Dictionary<Guid, T>();
        private readonly ILogger<MemoryStorage<T>> _logger;

        public MemoryStorage(ILogger<MemoryStorage<T>> logger)
        {
            _logger = logger;
            logger.LogInformation("Memory storage initialized");
        }


        public Task<IEnumerable<T>> Read()
        {
            return Task.FromResult(storage.Values.AsEnumerable());
        }

        public Task<T> Read(Guid Id)
        {

            var resource = storage.SingleOrDefault(x => x.Key == Id).Value;

            if (resource == null)
                throw new NotFoundException($"Could not find {typeof(T).Name} with ID {Id}");

            return Task.FromResult(resource);
        }

        public Task<T> Create(T resource)
        {
            storage.Add(resource.Id, resource);
            return Task.FromResult(resource);
        }

        public Task Delete(Guid Id)
        {
            storage.Remove(Id);
            return Task.CompletedTask;
        }


        public Task<T> Update(T resource)
        {
            if (storage[resource.Id] == null)
                throw new NotFoundException();

            storage[resource.Id] = resource;
            return Task.FromResult(resource);
        }
    }
}