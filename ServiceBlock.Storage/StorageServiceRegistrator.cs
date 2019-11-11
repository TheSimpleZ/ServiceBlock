using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ServiceBlock.Interface;
using ServiceBlock.Storage.Options;

namespace ServiceBlock.Storage
{
    public class StorageServiceRegistrator : IServiceConfiguration
    {
        public void Registrations(IServiceCollection services, IConfiguration config)
        {
            var section = config.GetSection(nameof(MongoDb));
            services.Configure<MongoDb>(section);
        }

        public void WarmUp(IServiceProvider services)
        {
        }
    }
}