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
    public abstract class Storage<T> where T : AbstractResource
    {
        private readonly ILogger<Storage<T>> _logger;
        private readonly ResourceTransformer<T>? _transformer;

        public event EventHandler<T>? OnCreate;
        public event EventHandler<T>? OnUpdate;
        public event EventHandler<T>? OnDelete;

        protected Storage(ILogger<Storage<T>> logger, ResourceTransformer<T>? transformer = null)
        {
            this._logger = logger;
            this._transformer = transformer;

            logger.LogDebug("{StorageType} initialized", GetType().PrettyName());

        }

        private bool IsValidTransform(string name) => _transformer != null && _transformer.GetType().HasOverriddenMethod(name);
        private bool ResourceHasEvent(ResourceEventType et) => typeof(T).GetAttributeValue((EmitEventsAttribute a) => a.EventTypes)?.Contains(et) == true;


        public async Task<IEnumerable<T>> Read(Dictionary<string, string> searchParams)
        {
            var resources = await ReadItems(searchParams);


            return IsValidTransform(nameof(_transformer.OnRead))
                    ? await Task.WhenAll(resources.Select(r => _transformer!.OnRead(r)))
                    : resources;
        }
        public async Task<T> Read(Guid Id)
        {
            var resource = await ReadItem(Id);

            return IsValidTransform(nameof(_transformer.OnRead))
                    ? (await _transformer!.OnRead(resource))
                    : resource;
        }

        public async Task<T> Create(T resource)
        {
            if (IsValidTransform(nameof(_transformer.OnCreate)))
                resource = await _transformer!.OnCreate(resource);

            var created = await CreateItem(resource);

            if (ResourceHasEvent(ResourceEventType.Created))
                await SendEvent(() => OnCreate?.Invoke(this, created), async () => await DeleteItem(resource.Id), resource);

            return created;
        }
        public async Task<T> Update(T resource)
        {
            if (IsValidTransform(nameof(_transformer.OnUpdate)))
                resource = await _transformer!.OnUpdate(resource);
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

        /// <summary>
        /// Get all items from database filtered by searchParams
        /// </summary>
        /// <param name="searchParams">A dictionary mapping property name to expected value as a string</param>
        /// <returns>All items of type T from the database</returns>
        protected abstract Task<IEnumerable<T>> ReadItems(Dictionary<string, string> searchParams);

        /// <summary>
        /// Get item from database by Id
        /// </summary>
        /// <param name="Id">The Id of the resource</param>
        /// <returns>The requested resource</returns>
        protected abstract Task<T> ReadItem(Guid Id);

        /// <summary>
        /// Create resource
        /// </summary>
        /// <param name="resource">Resource to be created</param>
        /// <returns>The created resource</returns>
        protected abstract Task<T> CreateItem(T resource);

        /// <summary>
        /// Update resource
        /// </summary>
        /// <param name="resource">New version of a resource</param>
        /// <returns>The updated resource</returns>
        protected abstract Task<T> UpdateItem(T resource);

        /// <summary>
        /// Delete resource
        /// </summary>
        /// <param name="Id">Id of resource to delete</param>
        /// <returns>Nothing</returns>
        protected abstract Task DeleteItem(Guid Id);
    }
}