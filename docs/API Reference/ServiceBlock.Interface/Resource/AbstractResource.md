AbstractResource
======
> Namespace: ServiceBlock.Interface.Resource




```
public abstract class AbstractResource
```




Id
------

```
[ReadOnly(true)]
```



GetQueryableProperties(Type)
------

```
public static IEnumerable<PropertyInfo> GetQueryableProperties(Type type) => type.GetProperties().Where(p => p.HasAttribute<QueryableAttribute>());
```
### Parameters
Name | Description
--- | ---
type | 




