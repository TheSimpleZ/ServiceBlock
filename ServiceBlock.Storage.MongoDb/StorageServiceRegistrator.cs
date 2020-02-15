using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ServiceBlock.Interface;
using ServiceBlock.Storage.MongoDb.Options;

namespace ServiceBlock.Storage.MongoDb
{
    public class StorageServiceRegistrator : IServiceConfiguration
    {
        public void Registrations(IServiceCollection services, IConfiguration config)
        {
            var section = config.GetSection(nameof(MongoDb));
            services.Configure<Options.MongoDb>(section);
        }

        public void WarmUp(IServiceProvider services)
        {
        }
    }
}