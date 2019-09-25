using System.Threading.Tasks;
using ServiceBlock.Interface.Resource;

namespace ServiceBlock.Messaging
{
    public interface IResourceEventEmitter
    {
        Task Publish<T>(T resource, CrudEventType eventType) where T : AbstractResource;
    }
}