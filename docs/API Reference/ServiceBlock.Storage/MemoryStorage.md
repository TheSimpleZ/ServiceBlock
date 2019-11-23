MemoryStorage
======
> Namespace: ServiceBlock.Storage

In-memory resource storage

```
public class MemoryStorage<T> : Storage<T> where T : AbstractResource
```

### Parameters

Name | Description
--- | ---
T | The resource type


## Constructors

MemoryStorage(ILogger<MemoryStorage<T>>, ResourceTransformer<T>?)
------


```
public MemoryStorage(ILogger<MemoryStorage<T>> logger, ResourceTransformer<T>? transformer = null) : base(logger, transformer)
```




## Methods

ReadItems(Dictionary<string, string>)
------


```
protected override Task<IEnumerable<T>> ReadItems(Dictionary<string, string> searchParams)
```





ReadItem(Guid)
------


```
protected override Task<T> ReadItem(Guid Id)
```





CreateItem(T)
------


```
protected override Task<T> CreateItem(T resource)
```





DeleteItem(Guid)
------


```
protected override Task DeleteItem(Guid Id)
```





UpdateItem(T)
------


```
protected override Task<T> UpdateItem(T resource)
```





