using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mService.Interface
{
    public abstract class ResourceEventListener<T>
    {
        public virtual Task<IEnumerable<T>> OnGet(IEnumerable<T> resources)
        {
            return Task.FromResult(resources);
        }
        public virtual Task<T> OnGet(T resource)
        {
            return Task.FromResult(resource);
        }

        public virtual Task<T> OnCreate(T resource)
        {
            return Task.FromResult(resource);
        }
        public virtual Task<T> OnReplace(T resource)
        {
            return Task.FromResult(resource);
        }
        public virtual Task OnDelete(Guid Id)
        {
            return Task.CompletedTask;
        }

    }
}