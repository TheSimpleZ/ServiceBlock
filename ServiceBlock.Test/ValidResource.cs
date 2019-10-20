using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;
using ServiceBlock.Storage;



namespace ServiceBlock.Test
{
    [Storage(typeof(MemoryStorage<>))]
    public class ValidResource : AbstractResource
    {
        public int TestProp { get; set; } = 0;
    }
}