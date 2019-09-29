using System;
using System.Reflection;
using System.Linq;
namespace ServiceBlock.Extensions
{
    public static class TypeExtensions
    {
        public static bool HasOverriddenMethod(this Type t, string methodName)
        {
            var m = t.GetMethod(methodName);
            return m.GetBaseDefinition().DeclaringType != m.DeclaringType;
        }

        public static TValue GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
        {
            var att = type.GetCustomAttributes<TAttribute>(true).FirstOrDefault();

            if (att != null)
            {
                return valueSelector(att);
            }

            return default;
        }

        public static bool HasAttribute<T>(this Type type) where T : Attribute
        {
            return type.GetCustomAttributes<T>(true).Any();
        }
    }
}