using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroNet.Interface;
using WeatherForecast.Interface;

namespace WeatherForecast
{
    public class ForecastEventListener : IResourceEventListener<WeatherForecasts>
    {
        public Task<WeatherForecasts> OnCreate(WeatherForecasts resource)
        {
            resource.Id = Guid.NewGuid();
            return Task.FromResult(resource);
        }

        public async Task OnDelete(Guid Id)
        {
            return;
        }

        public Task<IEnumerable<WeatherForecasts>> OnGet(IEnumerable<WeatherForecasts> resources)
        {
            return Task.FromResult(resources);
        }

        public async Task<WeatherForecasts> OnGet(WeatherForecasts resource)
        {
            resource.Summary = "Ha hahaha gahahah";
            return resource;
        }

        public Task<WeatherForecasts> OnReplace(WeatherForecasts resource)
        {
            throw new NotImplementedException();
        }
    }
}