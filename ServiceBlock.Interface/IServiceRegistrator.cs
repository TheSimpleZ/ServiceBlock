using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceBlock.Interface
{
    public interface IServiceConfiguration
    {
        void Registrations(IServiceCollection services, IConfiguration config);
        void WarmUp(IServiceProvider services);
    }
}