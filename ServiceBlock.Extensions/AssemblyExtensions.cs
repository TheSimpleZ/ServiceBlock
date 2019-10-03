using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ServiceBlock.Extensions
{
    public static class AssemblyExtensions
    {

        public static IEnumerable<Type> GetAllTypes(this Assembly asm, bool recursive = false)
        {
            var asmName = asm.GetName().Name;

            if (asmName == null)
                throw new InvalidOperationException("Could not access entry assembly name.");

            bool isServiceBlockAssembly(AssemblyName a) => a.Name?.StartsWith("ServiceBlock") == true || a.Name?.Split('.').FirstOrDefault().StartsWith(asmName) == true;

            var referencedBlockAssemblies = asm.GetReferencedAssemblies()
                                                 .Where(isServiceBlockAssembly);

            var blockTypes = new List<Type>();

            do
            {
                var loaded = referencedBlockAssemblies.Select(a => Assembly.Load(a));
                blockTypes.AddRange(loaded.SelectMany(a => a.GetExportedTypes()));
                referencedBlockAssemblies = loaded.SelectMany(a => a.GetReferencedAssemblies().Where(isServiceBlockAssembly));
            } while (referencedBlockAssemblies.Any() && recursive);

            return asm.GetExportedTypes().Concat(blockTypes);
        }


    }
}