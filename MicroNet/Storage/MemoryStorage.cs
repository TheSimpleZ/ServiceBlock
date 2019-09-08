using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MicroNet.Storage
{
    public class MemoryStorage<T> : IStorage<T> where T : IResource
    {
        private Dictionary<Guid, T> storage = new Dictionary<Guid, T>();

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

        public Task<IEnumerable<T>> Get()
        {
            return Task.FromResult(storage.Values.AsEnumerable());
        }

        public Task<T> Get(Guid Id)
        {
            return Task.FromResult(storage.FirstOrDefault(x => x.Key == Id).Value);
        }

        public Task<T> Replace(T resource)
        {
            storage[resource.Id] = resource;
            return Task.FromResult(resource);
        }
    }
}