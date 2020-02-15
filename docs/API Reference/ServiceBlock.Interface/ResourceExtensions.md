ResourceExtensions
======
> Namespace: ServiceBlock.Interface



```
public static class ResourceExtensions
```

## Methods

### GetQueryableProperties(Type)

Retrives a list of all properties with the QueryableAttribute.

```csharp
public static IEnumerable<PropertyInfo> GetQueryableProperties(this Type type) => type.GetProperties().Where(p => p.HasAttribute<QueryableAttribute>());
```





### GetServiceName(Type)

This method gets the name of the service that the resource belongs to.

```csharp
public static string GetServiceName(this Type type) => type.Assembly.GetName().Name.Split('.').FirstOrDefault();
```





