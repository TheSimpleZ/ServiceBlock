using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;

namespace ServiceBlock.Extensions
{
    static class ServiceCollectionExtensions
    {
        public static void AddResourceEventListeners(this IServiceCollection services)
        {
            services.Scan(scan =>
                scan.FromEntryAssembly()
                    .AddClasses(classes => classes.AssignableTo(typeof(ResourceTransformer<>)))
                    .As(classes => new[] { classes.BaseType }) // TODO: FIX BUG
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