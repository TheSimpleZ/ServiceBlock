using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ServiceBlock.Extensions;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;

namespace ServiceBlock.Messaging
{
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


        public ResourceEventListener(ILogger<ResourceEventListener<T>> logger, EventClient messageClient)
        {
            // If type T is defined in the same service that's running
            if (typeof(T).Assembly.GetName().Name.StartsWith(BaseBlock.Name))
            {
                logger.LogCritical("The resource {ResourceType} is defined in the same service as it's event listener. Please use the other constructor and supply a {StorageName} object", typeof(T), nameof(Storage<T>));
                throw new ArgumentException($"Provide a {nameof(Storage<T>)} not a {nameof(EventClient)} for types defined in the same service");
            }

            messageClient.MessageReceived += (sender, args) =>
            {
                if (args.Resource?.GetType() == typeof(T))
                {
                    logger.LogInformation("{EventType} event received for {Resource}", args.EventType, (T)args.Resource);
                    switch (args.EventType)
                    {
                        case ResourceEventType.Created when CreateIsOverride:
                            OnCreate(args.Resource);
                            break;
                        case ResourceEventType.Updated when UpdateIsOverride:
                            OnUpdate(args.Resource);
                            break;
                        case ResourceEventType.Deleted when DeleteIsOverride:
                            OnDelete(args.Resource);
                            break;
                    };
                }
            };



            logger.LogDebug("External listener {ListenerName} initialized. Listening to {EventTypes} events", GetType().Name, ListeningTo());
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

        public virtual void OnCreate(T resource) => throw new NotImplementedException();
        public virtual void OnUpdate(T resource) => throw new NotImplementedException();
        public virtual void OnDelete(T resource) => throw new NotImplementedException();
    }
}