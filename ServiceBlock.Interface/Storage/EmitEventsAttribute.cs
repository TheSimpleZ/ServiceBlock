using System;
using System.Collections.Generic;
using System.Linq;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Interface.Storage;

namespace ServiceBlock.Interface.Storage
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class EmitEventsAttribute : Attribute
    {
        public EmitEventsAttribute(params ResourceEventType[] eventTypes)
        {
            EventTypes = eventTypes.Any() ? eventTypes : Enum.GetValues(typeof(ResourceEventType)).Cast<ResourceEventType>();
        }

        public IEnumerable<ResourceEventType> EventTypes { get; private set; }
    }
}