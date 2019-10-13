using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using ServiceBlock.Extensions;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;

namespace ServiceBlock.Messaging
{
    class ResourceEventPublisher<T> where T : AbstractResource
    {
        public ResourceEventPublisher(Storage<T> storage, EventClient messageClient, ILogger<ResourceEventPublisher<T>> logger)
        {
            EventHandler<T> publish(ResourceEventType type) => (sender, eventArgs) => messageClient.Publish(type, eventArgs);

            var eventsToEmit = typeof(T).GetAttributeValue((EmitEventsAttribute attr) => attr.EventTypes);


            if (eventsToEmit.Contains(ResourceEventType.Created))
                storage.OnCreate += publish(ResourceEventType.Created);

            if (eventsToEmit.Contains(ResourceEventType.Updated))
                storage.OnUpdate += publish(ResourceEventType.Updated);

            if (eventsToEmit.Contains(ResourceEventType.Deleted))
                storage.OnDelete += publish(ResourceEventType.Deleted);

            logger.LogDebug("Event publisher for resource {ResourceType} initialized. Emitting {EventTypes} events", typeof(T).Name, eventsToEmit);
        }
    }
}