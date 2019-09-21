using System;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;

namespace SampleService.Interface
{
    [Storage(typeof(MemoryStorage<Invoice>))]
    public class Invoice : IResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}