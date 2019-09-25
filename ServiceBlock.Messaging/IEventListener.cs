using ServiceBlock.Interface.Resource;

namespace ServiceBlock.Messaging
{
    public interface IEventListener<T> where T : AbstractResource
    {

    }
}