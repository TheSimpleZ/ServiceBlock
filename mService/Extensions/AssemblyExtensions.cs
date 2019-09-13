using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using mService.Interface;
using mService.Interface.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace mService.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetAllTypes(this Assembly asm)
        {
            var referencedTypes = asm.GetReferencedAssemblies()
                                                 .Where(a => !a.Name.StartsWith("Microsoft") && !a.Name.StartsWith("System"))
                                                 .SelectMany(a => Assembly.Load(a).GetExportedTypes());

            return asm.GetExportedTypes().Concat(referencedTypes);
        }
    }
}