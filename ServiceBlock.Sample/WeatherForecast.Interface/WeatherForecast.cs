using System;
using System.ComponentModel;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;
using ServiceBlock.Messaging;
using ServiceBlock.Storage;

namespace WeatherForecast.Interface
{
    [Storage(typeof(MemoryStorage<>))]
    [ReadOnly(true)]
    public class WeatherForecasts : AbstractResource
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }


    }
}
