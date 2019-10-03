using System;
using System.Linq;

namespace ServiceBlock.Extensions
{
    public static class ResourceExtensions
    {
        public static string GetServiceName(this Type resource)
        {
            return resource.Assembly.GetName().Name.Split('.').FirstOrDefault();
        }
    }
}