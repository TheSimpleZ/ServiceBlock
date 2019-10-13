using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;
using ServiceBlock.Storage;

namespace SampleService.Interface
{
    [Storage(typeof(MemoryStorage<>))]
    public class Invoice : AbstractResource
    {
        public string Name { get; set; }
    }
}