using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ServiceBlock.Extensions
{
    /// <summary>
    /// This class provides methods to easily access a Blocks properties.
    /// </summary>
    public abstract class BaseBlock
    {
        public static string? Name => Assembly.GetEntryAssembly()?.GetName().Name;

        private static bool isServiceBlockAssembly(string a) => a.StartsWith("ServiceBlock") == true || a.Split('.').FirstOrDefault().StartsWith(Name) == true;


        public static IEnumerable<Type> GetBlockTypes()
        {

            var allDlls = Directory.EnumerateFiles(System.AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.AllDirectories);
            var serviceBlockDlls = allDlls.Where(f => isServiceBlockAssembly(Path.GetFileNameWithoutExtension(f)));

            return serviceBlockDlls.SelectMany(dll =>
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
}