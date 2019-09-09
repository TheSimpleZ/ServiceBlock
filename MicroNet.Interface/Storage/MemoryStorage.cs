using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MicroNet.Interface.Storage
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

            var resource = storage.SingleOrDefault(x => x.Key == Id).Value;

            if (resource == null)
                throw new NotFoundException();

            return Task.FromResult(resource);
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