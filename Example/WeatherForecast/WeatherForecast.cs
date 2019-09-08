using System;
using MicroNet;
using MicroNet.Startup;

namespace WeatherForecast
{
    [Route("/WeatherForecast")]
    public class WeatherForecast : IResource
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
        public Guid Id { get; set; }
    }
}
