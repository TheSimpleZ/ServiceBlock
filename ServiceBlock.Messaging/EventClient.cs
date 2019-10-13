using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using ServiceBlock.Extensions;
using ServiceBlock.Interface.Storage;

namespace ServiceBlock.Messaging
{
    public abstract class EventClient
    {

        public abstract void Publish<T>(ResourceEventType type, T payload);
        public event EventHandler<ResourceEventArgs>? MessageReceived;

        protected readonly IEnumerable<string> SubscriptionServiceNames = BaseBlock.GetBlockTypes()
            .Where(t => t.IsSubclassOfRawGeneric(typeof(ResourceEventListener<>)))
            .Select(t => t.BaseType.GetGenericArguments().Single().GetServiceName());

        protected virtual void OnMessageReceived(ResourceEventArgs args)
        {
            MessageReceived?.Invoke(this, args);
        }
    }
}