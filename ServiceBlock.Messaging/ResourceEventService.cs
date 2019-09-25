using System;
using ServiceBlock.Interface.Resource;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace ServiceBlock.Messaging
{

    public abstract class ResourceEventService
    {
        public event EventHandler<AbstractResource>? ResourceCreated;
        public event EventHandler<AbstractResource>? ResourceUpdated;
        public event EventHandler<AbstractResource>? ResourceDeleted;

        public virtual void OnEventReceived<T>(T resource, ResourceEventType eventType) where T : AbstractResource
        {

            EventHandler<AbstractResource>? handler = eventType switch
            {
                ResourceEventType.Created => ResourceCreated,
                ResourceEventType.Updated => ResourceUpdated,
                ResourceEventType.Deleted => ResourceDeleted
            };

            if (handler != null)
            {
                handler(this, resource);
            }
        }


        public abstract Task Publish<T>(ResourceEventType eventType, T resource) where T : AbstractResource;

    }
}