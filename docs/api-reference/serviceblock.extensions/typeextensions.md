# TypeExtensions

> Namespace: ServiceBlock.Extensions

```text
public static class TypeExtensions
```

## Methods

### HasOverriddenMethod\(Type, string\)

```csharp
public static bool HasOverriddenMethod(this Type t, string methodName)
```

### GetAttributeValue\(Type, Func\)

```csharp
public static TValue? GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute where TValue : class
```

### PrettyName\(Type\)

```csharp
public static string PrettyName(this Type type)
```

### HasAttribute\(Type\)

```csharp
public static bool HasAttribute<T>(this Type type) where T : Attribute
```

### HasAttribute\(PropertyInfo\)

```csharp
public static bool HasAttribute<T>(this PropertyInfo type) where T : Attribute
```

### GetJsonType\(PropertyInfo\)

```csharp
public static string GetJsonType(this PropertyInfo pi) => new JSchemaGenerator().Generate(pi.PropertyType).Type.ToString();
```

### IsSubclassOfRawGeneric\(Type, Type\)

```csharp
public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic)
```

