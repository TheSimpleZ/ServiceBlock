# AbstractResource

> Namespace: ServiceBlock.Interface.Resource

```text
public abstract class AbstractResource
```

## Id

```text
[ReadOnly(true)]
```

## GetQueryableProperties\(Type\)

```text
public static IEnumerable<PropertyInfo> GetQueryableProperties(Type type) => type.GetProperties().Where(p => p.HasAttribute<QueryableAttribute>());
```

### Parameters

| Name | Description |
| :--- | :--- |
| type |  |

