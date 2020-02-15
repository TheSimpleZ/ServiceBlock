using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ServiceBlock.Extensions;
using ServiceBlock.Interface.Resource;

namespace ServiceBlock.Interface
{
    public static class ResourceExtensions
    {
        // Retrives a list of all properties with the QueryableAttribute
        public static IEnumerable<PropertyInfo> GetQueryableProperties(this Type type) => type.GetProperties().Where(p => p.HasAttribute<QueryableAttribute>());

        // This method gets the name of the service that the resource belongs to
        public static string GetServiceName(this Type type) => type.Assembly.GetName().Name.Split('.').FirstOrDefault();
    }
}