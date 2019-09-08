using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroNet;

namespace WeatherForecast
{
    public class ForecastEventListener : IResourceEventListener<WeatherForecast>
    {
        public Task<WeatherForecast> OnCreate(WeatherForecast resource)
        {
            resource.Id = Guid.NewGuid();
            return Task.FromResult(resource);
        }

        public Task<WeatherForecast> OnDelete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WeatherForecast>> OnGet(IEnumerable<WeatherForecast> resources)
        {
            throw new NotImplementedException();
        }

        public async Task<WeatherForecast> OnGet(WeatherForecast resource)
        {
            resource.Summary = "Ha hahaha gahahah";
            return resource;
        }

        public Task<WeatherForecast> OnReplace(WeatherForecast resource)
        {
            throw new NotImplementedException();
        }
    }
}