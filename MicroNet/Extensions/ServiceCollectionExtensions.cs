using System.Linq;
using System.Reflection;
using MicroNet.Interface;
using MicroNet.Interface.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace MicroNet.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddResourceEventListeners(this IServiceCollection services)
        {
            services.Scan(scan =>
                scan.FromEntryAssembly()
                    .AddClasses(classes => classes.AssignableTo(typeof(IResourceEventListener<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );
        }

        public static void AddStorageServices(this IServiceCollection services)
        {
            var storageAttributes = Assembly.GetEntryAssembly().GetAllTypes().Select(t => t.GetCustomAttribute<StorageAttribute>()).Where(t => t != null);

            foreach (var attr in storageAttributes)
            {
                var innerType = attr.storageType.GetGenericArguments().Single();
                services.AddSingleton(typeof(IStorage<>).MakeGenericType(innerType), attr.storageType);
            }
        }
    }
}