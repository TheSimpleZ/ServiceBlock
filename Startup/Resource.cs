using System;

namespace Startup
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ResourceAttribute : Attribute
    {
        public ResourceAttribute(string route)
        {
            Route = route;
        }

        public string Route { get; set; }
    }
}