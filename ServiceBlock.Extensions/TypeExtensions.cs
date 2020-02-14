using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Schema.Generation;

namespace ServiceBlock.Extensions
{
    public static class TypeExtensions
    {
        public static bool HasOverriddenMethod(this Type t, string methodName)
        {
            var m = t.GetMethod(methodName);
            return m.GetBaseDefinition().DeclaringType != m.DeclaringType;
        }

        public static TValue? GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute where TValue : class
        {
            var att = type.GetCustomAttributes<TAttribute>(true).FirstOrDefault();

            if (att != null)
            {
                return valueSelector(att);
            }

            return default;
        }

        public static string PrettyName(this Type type)
        {
            if (type.GetGenericArguments().Length == 0)
            {
                return type.Name;
            }
            var genericArguments = type.GetGenericArguments();
            var typeDefeninition = type.Name;
            var unmangledName = typeDefeninition.Substring(0, typeDefeninition.IndexOf("`"));
            return unmangledName + "<" + String.Join(",", genericArguments.Select(PrettyName)) + ">";
        }

        public static bool HasAttribute<T>(this Type type) where T : Attribute
        {
            return type.GetCustomAttributes<T>(true).Any();
        }

        public static bool HasAttribute<T>(this PropertyInfo type) where T : Attribute
        {
            return type.GetCustomAttributes<T>(true).Any();
        }

        public static string GetJsonType(this PropertyInfo pi) => new JSchemaGenerator().Generate(pi.PropertyType).Type.ToString().ToLowerInvariant();


        public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic)
        {
            if (toCheck.BaseType?.IsGenericType == true && generic == toCheck.BaseType.GetGenericTypeDefinition())
            {
                return true;
            }

            return false;
        }
    }
}