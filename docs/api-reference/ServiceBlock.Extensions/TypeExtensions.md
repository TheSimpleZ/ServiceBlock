TypeExtensions
======
> Namespace: ServiceBlock.Extensions



```
public static class TypeExtensions
```

## Methods

HasOverriddenMethod(Type, string)
------


```
public static bool HasOverriddenMethod(this Type t, string methodName)
```





GetAttributeValue(Type, Func<TAttribute, TValue>)
------


```
public static TValue? GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute where TValue : class
```





PrettyName(Type)
------


```
public static string PrettyName(this Type type)
```





HasAttribute(Type)
------


```
public static bool HasAttribute<T>(this Type type) where T : Attribute
```





HasAttribute(PropertyInfo)
------


```
public static bool HasAttribute<T>(this PropertyInfo type) where T : Attribute
```





GetJsonType(PropertyInfo)
------


```
public static string GetJsonType(this PropertyInfo pi) => new JSchemaGenerator().Generate(pi.PropertyType).Type.ToString();
```





IsSubclassOfRawGeneric(Type, Type)
------


```
public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic)
```





