using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using ServiceBlock.Extensions;

namespace ServiceBlock.Interface.Resource
{
    public abstract class AbstractResource
    {
        [ReadOnly(true)]
        public virtual Guid Id { get; set; } = Guid.NewGuid();

        public static IEnumerable<PropertyInfo> GetQueryableProperties(Type type) => type.GetProperties().Where(p => p.HasAttribute<QueryableAttribute>());

    }
}