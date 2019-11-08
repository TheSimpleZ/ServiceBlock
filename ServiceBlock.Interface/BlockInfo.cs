using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ServiceBlock.Interface.Resource;

namespace ServiceBlock.Interface
{
    // This class provides methods to easily access a Blocks properties.
    public static class BlockInfo
    {
        // Name of the current service
        public static string? Name => Assembly.GetEntryAssembly()?.GetName().Name;

        private static bool isServiceBlockAssembly(string a) => a.StartsWith("ServiceBlock") == true || a.Split('.').FirstOrDefault().StartsWith(Name) == true;

        // All resources defined in the current service and the ServiceBlock Framework
        public static IEnumerable<Type> ResourceTypes => BlockTypes.Where(x => typeof(AbstractResource).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);

        public static IEnumerable<IServiceConfiguration> ServiceConfigurators =>
        BlockTypes
        .Where(t => t.IsClass && typeof(IServiceConfiguration).IsAssignableFrom(t))
        .Select(Activator.CreateInstance)
        .Cast<IServiceConfiguration>();



        public static IEnumerable<Type> BlockTypes =>
            Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.AllDirectories)
            .Where(f => isServiceBlockAssembly(Path.GetFileNameWithoutExtension(f)))
            .SelectMany(dll =>
            {
                try
                {
                    return Assembly.Load(Path.GetFileNameWithoutExtension(dll)).GetExportedTypes();
                }
                catch (FileLoadException)
                { return new Type[] { }; } // The Assembly has already been loaded.
                catch (BadImageFormatException)
                { return new Type[] { }; } // If a BadImageFormatException exception is thrown, the file is not an assembly.
            });

    }
}