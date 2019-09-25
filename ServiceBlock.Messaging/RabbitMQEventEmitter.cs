using System.Threading.Tasks;
using ServiceBlock.Interface.Resource;

namespace ServiceBlock.Messaging
{
    public class RabbitMQEventEmitter : IResourceEventEmitter
    {
        public Task Publish<T>(T resource, CrudEventType eventType) where T : AbstractResource
        {
            throw new System.NotImplementedException();
        }
    }
}