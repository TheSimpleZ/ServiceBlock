using Microsoft.Extensions.Logging;
using ServiceBlock.Interface.Storage;
using ServiceBlock.Messaging;
using WeatherForecast.Interface;

namespace WeatherForecast
{
    public class InvoiceEventListener : ResourceEventListener<Invoice>
    {
        public InvoiceEventListener(Storage<Invoice> storage, EventClient messageClient, ILogger<InvoiceEventListener> logger) : base(storage, messageClient, logger)
        {
        }

        public override void OnCreate(Invoice resource)
        {
            var id = resource.Id;
        }
    }
}