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

        public async Task OnDelete(Guid Id)
        {
            return;
        }

        public Task<IEnumerable<WeatherForecast>> OnGet(IEnumerable<WeatherForecast> resources)
        {
            return Task.FromResult(resources);
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