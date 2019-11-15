AbstractResource
======
> Namespace: ServiceBlock.Interface.Resource



```
public abstract class AbstractResource
```





## Properties

Id
------


```
[ReadOnly(true)]
public virtual Guid Id
```



## Methods

GetQueryableProperties(Type)
------


```
public static IEnumerable<PropertyInfo> GetQueryableProperties(Type type) => type.GetProperties().Where(p => p.HasAttribute<QueryableAttribute>());
```

### Parameters
Name | Description
--- | ---
type | 




GetServiceName(Type)
------


```
public static string GetServiceName(Type type) => type.Assembly.GetName().Name.Split('.').FirstOrDefault();
```

### Parameters
Name | Description
--- | ---
type | 





