using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroNet.Storage;

namespace WeatherForecast
{
    public class ForecastStorage : IStorage<WeatherForecast>
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast> Create(WeatherForecast resource)
        {
            throw new NotImplementedException();
        }

        public Task<WeatherForecast> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WeatherForecast>> Get()
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }));
        }

        public Task<WeatherForecast> Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<WeatherForecast> Replace(WeatherForecast resource)
        {
            throw new NotImplementedException();
        }
    }
}