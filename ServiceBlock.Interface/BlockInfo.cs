using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ServiceBlock.Interface.Resource;

namespace ServiceBlock.Interface
{
    /// <summary>
    /// This class provides methods to easily access a Blocks properties.
    /// </summary>
    public static class BlockInfo
    {
        /// <summary>
        /// Name of the current service
        /// </summary>
        public static string? Name => Assembly.GetEntryAssembly()?.GetName().Name;

        private static bool isServiceBlockAssembly(string a) => a.StartsWith("ServiceBlock") == true || a.Split('.').FirstOrDefault().StartsWith(Name) == true;

        /// <summary>
        /// All resources defined in the current service and the ServiceBlock Framework
        /// </summary>
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