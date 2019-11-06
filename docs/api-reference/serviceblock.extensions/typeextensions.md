# TypeExtensions

> Namespace: ServiceBlock.Extensions

```text
public static class TypeExtensions
```

## HasOverriddenMethod\(Type, string\)

```text
public static bool HasOverriddenMethod(this Type t, string methodName)
```

### Parameters

| Name | Description |
| :--- | :--- |
| t |  |
| methodName |  |

## GetAttributeValue\(Type, Func\)

```text
public static TValue? GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute where TValue : class
```

### Parameters

| Name | Description |
| :--- | :--- |
| type |  |
| valueSelector |  |

## PrettyName\(Type\)

```text
public static string PrettyName(this Type type)
```

### Parameters

| Name | Description |
| :--- | :--- |
| type |  |

## HasAttribute\(Type\)

```text
public static bool HasAttribute<T>(this Type type) where T : Attribute
```

### Parameters

| Name | Description |
| :--- | :--- |
| type |  |

## HasAttribute\(PropertyInfo\)

```text
public static bool HasAttribute<T>(this PropertyInfo type) where T : Attribute
```

### Parameters

| Name | Description |
| :--- | :--- |
| type |  |

## GetJsonType\(PropertyInfo\)

```text
public static string GetJsonType(this PropertyInfo pi) => new JSchemaGenerator().Generate(pi.PropertyType).Type.ToString();
```

### Parameters

| Name | Description |
| :--- | :--- |
| pi |  |

## IsSubclassOfRawGeneric\(Type, Type\)

```text
public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic)
```

### Parameters

| Name | Description |
| :--- | :--- |
| toCheck |  |
| generic |  |

