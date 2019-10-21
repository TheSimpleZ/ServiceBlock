using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;
using ServiceBlock.Storage;



namespace ServiceBlock.Test
{
    [Storage(typeof(MemoryStorage<>))]
    [EmitEvents]
    public class EmitEventsResource : AbstractResource
    {
        public int TestProp { get; set; } = 0;
    }
}