TypeExtensions
======
##### Namespace: ServiceBlock.Extensions




```
public static class TypeExtensions
```






HasOverriddenMethod(Type, string)
------

```
public static bool HasOverriddenMethod(this Type t, string methodName)
```
### Parameters
Name | Description
--- | ---
t | 
methodName | 




GetAttributeValue(Type, Func<TAttribute, TValue>)
------

```
public static TValue? GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute where TValue : class
```
### Parameters
Name | Description
--- | ---
type | 
valueSelector | 




PrettyName(Type)
------

```
public static string PrettyName(this Type type)
```
### Parameters
Name | Description
--- | ---
type | 




HasAttribute(Type)
------

```
public static bool HasAttribute<T>(this Type type) where T : Attribute
```
### Parameters
Name | Description
--- | ---
type | 




HasAttribute(PropertyInfo)
------

```
public static bool HasAttribute<T>(this PropertyInfo type) where T : Attribute
```
### Parameters
Name | Description
--- | ---
type | 




GetJsonType(PropertyInfo)
------

```
public static string GetJsonType(this PropertyInfo pi) => new JSchemaGenerator().Generate(pi.PropertyType).Type.ToString();
```
### Parameters
Name | Description
--- | ---
pi | 




IsSubclassOfRawGeneric(Type, Type)
------

```
public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic)
```
### Parameters
Name | Description
--- | ---
toCheck | 
generic | 




