using System;
using ServiceBlock.Interface.Resource;

namespace ServiceBlock.Messaging
{
    public interface IMessageClient
    {
        void Publish<T>(T payload);
        event EventHandler<ResourceEventArgs> OnReceive;
    }

    public class ResourceEventArgs
    {
        public dynamic? Resource { get; set; }
        public ResourceEventType EventType { get; set; }
    }
}