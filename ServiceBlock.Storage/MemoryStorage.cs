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
    public class MemoryStorage<T> : Storage<T> where T : AbstractResource
    {
        private Dictionary<Guid, T> storage = new Dictionary<Guid, T>();
        private readonly ILogger<MemoryStorage<T>> _logger;

        public MemoryStorage(ILogger<MemoryStorage<T>> logger)
        {
            _logger = logger;
            logger.LogInformation("Memory storage initialized");
        }


        protected override Task<IEnumerable<T>> ReadItems()
        {
            return Task.FromResult(storage.Values.AsEnumerable());
        }

        protected override Task<T> ReadItem(Guid Id)
        {

            var resource = storage.SingleOrDefault(x => x.Key == Id).Value;

            if (resource == null)
                throw new NotFoundException($"Could not find {typeof(T).Name} with ID {Id}");

            return Task.FromResult(resource);
        }

        protected override Task<T> CreateItem(T resource)
        {
            storage.Add(resource.Id, resource);
            return Task.FromResult(resource);
        }

        protected override Task DeleteItem(Guid Id)
        {
            storage.Remove(Id);
            return Task.CompletedTask;
        }


        protected override Task<T> UpdateItem(T resource)
        {
            if (storage[resource.Id] == null)
                throw new NotFoundException();

            storage[resource.Id] = resource;
            return Task.FromResult(resource);
        }
    }
}