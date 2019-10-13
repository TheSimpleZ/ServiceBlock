using Microsoft.Extensions.Logging;
using ServiceBlock.Interface.Storage;
using ServiceBlock.Messaging;
using WeatherForecast.Interface;

namespace WeatherForecast
{
    public class InvoiceEventListener : ResourceEventListener<Invoice>
    {
        public InvoiceEventListener(ILogger<InvoiceEventListener> logger, Storage<Invoice> storage) : base(logger, storage)
        {
        }

        public override void OnCreate(Invoice resource)
        {
            var id = resource.Id;
        }
    }
}