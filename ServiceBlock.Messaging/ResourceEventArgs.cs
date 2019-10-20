using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;

namespace ServiceBlock.Messaging
{
    public class ResourceEventArgs
    {
        public dynamic? Resource { get; set; }
        public ResourceEventType EventType { get; set; }

        public ResourceEventArgs(ResourceEventType type, dynamic resource)
        {
            Resource = resource;
            EventType = type;
        }
    }
}