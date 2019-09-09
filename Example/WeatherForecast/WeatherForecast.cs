using System;
using MicroNet;
using MicroNet.Startup;
using MicroNet.Storage;

namespace WeatherForecast
{
    [Storage(typeof(MemoryStorage<Invoice>))]
    public class WeatherForecast : IResource
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }


    }
}
