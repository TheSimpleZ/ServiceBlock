MongoDbStorage
======
> Namespace: ServiceBlock.Storage

ServiceBlock storage backed by mongo db.

```
public class MongoDbStorage<T> : Storage<T> where T : AbstractResource
```

### Parameters

Name | Description
--- | ---
T | The resource type


## Constructors

MongoDbStorage(ILogger<MemoryStorage<T>>, IConfiguration, IOptionsMonitor<MongoDb>, ResourceTransformer<T>?)
------


```
public MongoDbStorage(ILogger<MemoryStorage<T>> logger, IConfiguration config, IOptionsMonitor<MongoDb> options, ResourceTransformer<T>? transformer = null) : base(logger, transformer)
```




## Methods

ReadItems(Dictionary<string, string>)
------


```
protected override async Task<IEnumerable<T>> ReadItems(Dictionary<string, string> searchParams)
```





ReadItem(Guid)
------


```
protected override async Task<T> ReadItem(Guid Id)
```





CreateItem(T)
------


```
protected override async Task<T> CreateItem(T resource)
```





DeleteItem(Guid)
------


```
protected override async Task DeleteItem(Guid Id) => await resources.DeleteOneAsync(r => r.Id == Id);
```





UpdateItem(T)
------


```
protected override async Task<T> UpdateItem(T resource)
```





