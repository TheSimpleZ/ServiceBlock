using ServiceBlock.Interface.Resource;
using SampleService.Interface;
using System;
using System.Threading.Tasks;


namespace SampleService
{
    public class InvoiceEventListener : ResourceEventListener<Invoice>
    {

        public override Task<Invoice> OnCreate(Invoice resource)
        {
            resource.Id = Guid.NewGuid();
            return Task.FromResult(resource);
        }

    }
}