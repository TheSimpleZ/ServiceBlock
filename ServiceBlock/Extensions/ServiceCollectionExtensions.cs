using System.Linq;
using System.Reflection;
using ServiceBlock.Interface;
using ServiceBlock.Interface.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceBlock.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddResourceEventListeners(this IServiceCollection services)
        {
            services.Scan(scan =>
                scan.FromEntryAssembly()
                    .AddClasses(classes => classes.AssignableTo(typeof(ResourceEventListener<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );
        }

        public static void AddStorageServices(this IServiceCollection services)
        {
            var storageAttributes = Assembly.GetEntryAssembly()?.GetAllTypes().Select(t => t.GetCustomAttribute<StorageAttribute>()).Where(t => t != null);
            if (storageAttributes != null)
                foreach (var attr in storageAttributes)
                {
                    if (attr != null)
                    {
                        var innerType = attr.storageType.GetGenericArguments().Single();
                        services.AddSingleton(typeof(IStorage<>).MakeGenericType(innerType), attr.storageType);
                    }
                }
        }
    }
}