using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ServiceBlock.Extensions;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;

namespace ServiceBlock.Storage
{
    // Summary: Abstract class meant to be extended when creating resource event listeners.
    // Parameters:
    //   T: The resource to listen to
    public abstract class ResourceEventListener<T> where T : AbstractResource
    {
        private bool CreateIsOverride => GetType().HasOverriddenMethod(nameof(OnCreate));
        private bool UpdateIsOverride => GetType().HasOverriddenMethod(nameof(OnUpdate));
        private bool DeleteIsOverride => GetType().HasOverriddenMethod(nameof(OnDelete));

        private List<ResourceEventType> ListeningTo()
        {
            var listeningTo = new List<ResourceEventType>();
            if (CreateIsOverride) listeningTo.Add(ResourceEventType.Created);
            if (UpdateIsOverride) listeningTo.Add(ResourceEventType.Updated);
            if (DeleteIsOverride) listeningTo.Add(ResourceEventType.Deleted);
            return listeningTo;
        }

        public ResourceEventListener(ILogger<ResourceEventListener<T>> logger, Storage<T> storage)
        {
            if (CreateIsOverride)
                storage.OnCreate += (sender, eventArgs) => OnCreate(eventArgs);

            if (UpdateIsOverride)
                storage.OnUpdate += (sender, eventArgs) => OnUpdate(eventArgs);

            if (DeleteIsOverride)
                storage.OnDelete += (sender, eventArgs) => OnDelete(eventArgs);

            logger.LogDebug("Internal listener {ListenerName} initialized. Listening to {EventTypes} events", GetType().Name, ListeningTo());
        }

        // Summary: This method will be fired whenever a resource of type T is created
        // Parameters:
        //   resource: The resource that was created
        public virtual void OnCreate(T resource) => throw new NotImplementedException();

        // Summary: This method will be fired whenever a resource of type T is updated
        // Parameters:
        //   resource: The resource that was updated
        public virtual void OnUpdate(T resource) => throw new NotImplementedException();

        // Summary: This method will be fired whenever a resource of type T is deleted
        // Parameters:
        //   resource: The resource that was deleted
        public virtual void OnDelete(T resource) => throw new NotImplementedException();
    }
}