using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceBlock.Interface.Resource
{
    // Summary: This class can be extended to transform a resource before it's read/written
    //   Parameters:
    //     T: The type of resource to transform
    public abstract class ResourceTransformer<T> where T : AbstractResource
    {
        // Summary: This method will be fired after the resource has been retrived from storage, but before it's returned to the client.
        //   Parameters:
        //     resource: The resource that was retrieved from storage
        //   Returns: The item to be returned to the client.
        public virtual Task<T> OnRead(T resource)
        {
            return Task.FromResult(resource);
        }

        // Summary: This method will be fired after the resource has been received from the API, but before it's written to the storage.
        //   Parameters:
        //     resource: The resource that was received from the API
        //   Returns: The item to be written to storage.
        public virtual Task<T> OnCreate(T resource)
        {
            return Task.FromResult(resource);
        }

        // Summary: This method will be fired after the resource has been received from the API, but before it's written to the storage.
        //   Parameters:
        //     resource: The resource that was received from the API
        //   Returns: The item to be written to storage.
        public virtual Task<T> OnUpdate(T resource)
        {
            return Task.FromResult(resource);
        }

    }
}