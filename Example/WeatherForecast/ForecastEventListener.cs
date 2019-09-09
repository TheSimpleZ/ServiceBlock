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

        public Task OnDelete(Guid Id)
        {
            return Task.CompletedTask;
        }

        public Task<IEnumerable<WeatherForecasts>> OnGet(IEnumerable<WeatherForecasts> resources)
        {
            return Task.FromResult(resources);
        }

        public Task<WeatherForecasts> OnGet(WeatherForecasts resource)
        {
            resource.Summary = "Ha hahaha hahaha";
            return Task.FromResult(resource);
        }

        public Task<WeatherForecasts> OnReplace(WeatherForecasts resource)
        {
            throw new NotImplementedException();
        }
    }
}