using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ServiceBlock.Extensions
{
    public static class Block
    {
        public static string? Name => Assembly.GetEntryAssembly()?.GetName().Name;

        public static IEnumerable<Type> GetAppTypes() => Assembly.GetEntryAssembly().GetAllTypes();

        public static IEnumerable<Type> GetLibTypes() => Assembly.GetCallingAssembly().GetAllTypes();
    }
}