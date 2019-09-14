using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ServiceBlock.Interface;
using ServiceBlock.Interface.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceBlock.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetAllTypes(this Assembly asm)
        {
            var referencedTypes = asm.GetReferencedAssemblies()
                                                 .Where(a => a.Name?.StartsWith("Microsoft") == false && a.Name?.StartsWith("System") == false)
                                                 .SelectMany(a => Assembly.Load(a).GetExportedTypes());

            return asm.GetExportedTypes().Concat(referencedTypes);
        }
    }
}