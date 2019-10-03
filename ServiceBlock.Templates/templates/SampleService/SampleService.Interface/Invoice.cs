using System;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;

namespace SampleService.Interface
{
    [Storage(typeof(MemoryStorage<>))]
    public class Invoice : AbstractResource
    {
        public string Name { get; set; }
    }
}