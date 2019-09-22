using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ServiceBlock.Extensions
{
    static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetAllTypes(this Assembly asm)
        {
            var asmName = asm.GetName().Name;

            if (asmName == null)
                throw new InvalidOperationException("Could not access entry assembly name.");

            var referencedTypes = asm.GetReferencedAssemblies()
                                                 .Where(a => a.Name?.StartsWith(asmName) == true)
                                                 .SelectMany(a => Assembly.Load(a).GetExportedTypes());

            return asm.GetExportedTypes().Concat(referencedTypes);
        }
    }
}