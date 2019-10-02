using System;
using ServiceBlock.Extensions;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;

namespace ServiceBlock.Messaging
{
    public abstract class ResourceEventListener<T> where T : AbstractResource
    {

        public ResourceEventListener(Storage<T> storage, EventClient messageClient)
        {

            var CreateIsOverride = GetType().HasOverriddenMethod(nameof(OnCreate));
            var UpdateIsOverride = GetType().HasOverriddenMethod(nameof(OnUpdate));
            var DeleteIsOverride = GetType().HasOverriddenMethod(nameof(OnDelete));

            // If type T is defined in the same service that's running
            // Subscribe to store events
            if (typeof(T).Assembly.GetName().Name.StartsWith(Block.Name))
            {

                if (CreateIsOverride)
                    storage.OnCreate += (sender, eventArgs) => OnCreate(eventArgs);

                if (UpdateIsOverride)
                    storage.OnUpdate += (sender, eventArgs) => OnUpdate(eventArgs);

                if (DeleteIsOverride)
                    storage.OnDelete += (sender, eventArgs) => OnDelete(eventArgs);
            }
            else // Subscribe to AMQP events
            {
                messageClient.MessageReceived += (sender, args) =>
                {
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
                };
            }
        }

        public virtual void OnCreate(T resource) => throw new NotImplementedException();
        public virtual void OnUpdate(T resource) => throw new NotImplementedException();
        public virtual void OnDelete(T resource) => throw new NotImplementedException();
    }
}