using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ServiceBlock.Extensions
{
    static class TypeExtensions
    {
        public static TValue GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
        {
            var att = type.GetCustomAttributes<TAttribute>(true).FirstOrDefault();

            if (att != null)
            {
                return valueSelector(att);
            }

            return default(TValue);
        }

        public static bool HasAttribute<T>(this Type type) where T : Attribute
        {
            return type.GetCustomAttributes<T>(true).Any();
        }

    }
}