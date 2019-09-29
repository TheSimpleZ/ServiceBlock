using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceBlock.Interface.Resource
{
    public abstract class ResourceTransformer<T> where T : AbstractResource
    {

        public virtual Task<T> OnRead(T resource)
        {
            return Task.FromResult(resource);
        }

        public virtual Task<T> OnCreate(T resource)
        {
            return Task.FromResult(resource);
        }
        public virtual Task<T> OnUpdate(T resource)
        {
            return Task.FromResult(resource);
        }

    }
}