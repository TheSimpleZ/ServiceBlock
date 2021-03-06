using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ServiceBlock.Extensions;
using ServiceBlock.Interface.Resource;

namespace ServiceBlock.Interface.Storage
{
    // Abstract storage class.
    // Use this class to implement different types of storages for your resources.
    public abstract class Storage<T> where T : AbstractResource
    {
        private readonly ILogger<Storage<T>> _logger;

        public event EventHandler<T>? OnCreate;
        public event EventHandler<T>? OnUpdate;
        public event EventHandler<T>? OnDelete;

        protected Storage(ILogger<Storage<T>> logger)
        {
            this._logger = logger;

            logger.LogDebug("{StorageType} initialized", GetType().PrettyName());

        }

        private bool ResourceHasEvent(ResourceEventType et) => typeof(T).GetAttributeValue((EmitEventsAttribute a) => a.EventTypes)?.Contains(et) == true;


        public async Task<IEnumerable<T>> Read(Dictionary<string, string> searchParams)
        {
            var resources = await ReadItems(searchParams);

            await Task.WhenAll(resources.Select(r => r.OnRead()));
            return resources;
        }
        public async Task<T> Read(Guid Id)
        {
            var resource = await ReadItem(Id);

            await resource.OnRead();
            return resource;
        }

        public async Task<T> Create(T resource)
        {
            await resource.OnCreate();

            var created = await CreateItem(resource);

            if (ResourceHasEvent(ResourceEventType.Created))
                await SendEvent(() => OnCreate?.Invoke(this, created), async () => await DeleteItem(resource.Id), resource);

            return created;
        }
        public async Task<T> Update(T resource)
        {
            await resource.OnUpdate();
            var oldResource = await Read(resource.Id);

            var updated = await UpdateItem(resource);

            if (ResourceHasEvent(ResourceEventType.Updated))
                await SendEvent(() => OnUpdate?.Invoke(this, updated), async () => await UpdateItem(oldResource), resource);


            return updated;
        }
        public async Task Delete(Guid Id)
        {

            var resource = await Read(Id);

            await DeleteItem(Id);

            if (ResourceHasEvent(ResourceEventType.Deleted))
                await SendEvent(() => OnDelete?.Invoke(this, resource), async () => await CreateItem(resource), resource);


        }

        private async Task SendEvent(Action eventHandler, Func<Task> rollback, T resource, [CallerMemberName] string callerName = "")
        {
            try
            {
                eventHandler();
                _logger.LogInformation("{EventType} event published for resource {Resource}", callerName, resource);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Could not send {EventType} event for resource {Resource}", callerName, resource);
                try
                {
                    await rollback();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex, "Could not roll back {EventType} for resource {Resource}", callerName, resource);
                    throw;
                }
                throw;
            }
        }


        // Summary: Get all items from database filtered by searchParams
        // Parameters: 
        //   searchParams: A dictionary mapping property name to expected value as a string
        // Returns: All items of type T from the database
        protected abstract Task<IEnumerable<T>> ReadItems(Dictionary<string, string> searchParams);


        // Summary: Get item from database by Id
        // Parameters:
        //   Id: The Id of the resource
        // Returns: The requested resource
        protected abstract Task<T> ReadItem(Guid Id);


        // Summary: Create resource
        // Parameters:
        //   resource: Resource to be created
        // Returns: The created resource
        protected abstract Task<T> CreateItem(T resource);


        // Summary: Update resource
        // Parameters:
        //   resource: New version of a resource
        // Returns: The updated resource
        protected abstract Task<T> UpdateItem(T resource);


        // Summary: Delete resource
        // Parameters:
        //   Id: Id of resource to delete
        protected abstract Task DeleteItem(Guid Id);
    }
}