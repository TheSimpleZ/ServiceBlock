using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceBlock.Extensions;
using ServiceBlock.Interface.Resource;

namespace ServiceBlock.Interface.Storage
{
    public abstract class Storage<T> where T : AbstractResource
    {
        private readonly ResourceTransformer<T>? _transformer;

        public event EventHandler<T>? OnCreate;
        public event EventHandler<T>? OnUpdate;
        public event EventHandler<T>? OnDelete;

        public Storage(ResourceTransformer<T>? transformer = null)
        {
            this._transformer = transformer;
        }

        private bool IsValidTransform(string name) => _transformer != null && _transformer.GetType().HasOverriddenMethod(name);


        public async Task<IEnumerable<T>> Read()
        {
            var resources = await InternalRead();


            return IsValidTransform(nameof(_transformer.OnRead))
                    ? await Task.WhenAll(resources.Select(r => _transformer!.OnRead(r)))
                    : resources;
        }
        public async Task<T> Read(Guid Id)
        {
            var resource = await InternalRead(Id);

            return IsValidTransform(nameof(_transformer.OnRead))
                    ? (await _transformer!.OnRead(resource))
                    : resource;
        }

        public async Task<T> Create(T resource)
        {
            if (IsValidTransform(nameof(_transformer.OnCreate)))
                resource = await _transformer!.OnCreate(resource);

            var created = await InternalCreate(resource);

            OnCreate?.Invoke(this, created);
            return created;
        }
        public async Task<T> Update(T resource)
        {
            if (IsValidTransform(nameof(_transformer.OnUpdate)))
                resource = await _transformer!.OnUpdate(resource);

            var updated = await InternalUpdate(resource);
            OnUpdate?.Invoke(this, updated);

            return updated;
        }
        public async Task Delete(Guid Id)
        {
            var resource = await InternalRead(Id);

            await InternalDelete(Id);
            OnDelete?.Invoke(this, resource);
        }

        protected abstract Task<IEnumerable<T>> InternalRead();
        protected abstract Task<T> InternalRead(Guid Id);

        protected abstract Task<T> InternalCreate(T resource);
        protected abstract Task<T> InternalUpdate(T resource);
        protected abstract Task InternalDelete(Guid Id);
    }
}