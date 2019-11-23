AbstractResource
======
> Namespace: ServiceBlock.Interface.Resource

This class describes resources in the service
To create a resource, you must extend this class

```
public abstract class AbstractResource
```

## Properties

###Id

This parameter is used to identify the resource in the API
If overridden, you must ensure uniqueness

```
[ReadOnly(true)]
public virtual Guid Id
```


## Methods

###GetQueryableProperties(Type)

Retrives a list of all properties with the QueryableAttribute

```
public static IEnumerable<PropertyInfo> GetQueryableProperties(Type type) => type.GetProperties().Where(p => p.HasAttribute<QueryableAttribute>());
```





###GetServiceName(Type)

This method gets the name of the service that the resource belongs to

```
public static string GetServiceName(Type type) => type.Assembly.GetName().Name.Split('.').FirstOrDefault();
```





