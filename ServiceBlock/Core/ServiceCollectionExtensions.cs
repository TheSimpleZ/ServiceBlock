using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceBlock.Extensions;
using ServiceBlock.Interface;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;

namespace ServiceBlock.Core
{
    static class ServiceCollectionExtensions
    {
        public static void AddResourceTransformers(this IServiceCollection services)
        {
            services.Scan(scan =>
                scan.FromEntryAssembly()
                    .AddClasses(classes => classes.AssignableTo(typeof(ResourceTransformer<>)))
                    .As(classes => new[] { classes.BaseType })
                    .WithSingletonLifetime()
            );
        }

        public static void RunServiceRegistrators(this IServiceCollection services, IConfiguration config)
        {
            RunServiceConfiguratons(sc => sc.Registrations(services, config));

        }

        public static void RunServiceWarmUp(this IServiceProvider services)
        {
            RunServiceConfiguratons(sc => sc.WarmUp(services));
        }

        private static void RunServiceConfiguratons(Action<IServiceConfiguration> action)
        {

            foreach (var serviceConfig in Block.ServiceConfigurators)
            {
                action(serviceConfig!);
            }
        }

        public static void AddStorageServices(this IServiceCollection services)
        {

            var storageTypes = Block.ResourceTypes
            .Select(t => (typeof(Storage<>).MakeGenericType(t!), t.GetAttributeValue((StorageAttribute a) => a.StorageType)!.MakeGenericType(t)));

            foreach (var (genericStorage, implementation) in storageTypes)
            {
                services.AddSingleton(genericStorage, implementation);
            }

        }
    }
}