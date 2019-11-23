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

MemoryStorage(ILogger<MemoryStorage<T>>)
------


```csharp
public MemoryStorage(ILogger<MemoryStorage<T>> logger) : base(logger)
```




## Methods

### ReadItems(Dictionary<string, string>)



```csharp
protected override Task<IEnumerable<T>> ReadItems(Dictionary<string, string> searchParams)
```





### ReadItem(Guid)



```csharp
protected override Task<T> ReadItem(Guid Id)
```





### CreateItem(T)



```csharp
protected override Task<T> CreateItem(T resource)
```





### DeleteItem(Guid)



```csharp
protected override Task DeleteItem(Guid Id)
```





### UpdateItem(T)



```csharp
protected override Task<T> UpdateItem(T resource)
```





