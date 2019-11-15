MongoDbStorage
======
> Namespace: ServiceBlock.Storage

Summary: ServiceBlock storage backed by mongo db.
  Parameters:
    T: The resource type

```
public class MongoDbStorage<T> : Storage<T> where T : AbstractResource
```

## Constructors

MongoDbStorage(ILogger<MemoryStorage<T>>, IConfiguration, IOptions<MongoDb>, ResourceTransformer<T>?)
------


```
public MongoDbStorage(ILogger<MemoryStorage<T>> logger, IConfiguration config, IOptions<MongoDb> options, ResourceTransformer<T>? transformer = null) : base(logger, transformer)
```

### Parameters
Name | Description
--- | ---
logger | 
config | 
options | 
transformer | 








## Methods

ReadItems(Dictionary<string, string>)
------


```
protected override async Task<IEnumerable<T>> ReadItems(Dictionary<string, string> searchParams)
```

### Parameters
Name | Description
--- | ---
searchParams | 




ReadItem(Guid)
------


```
protected override async Task<T> ReadItem(Guid Id)
```

### Parameters
Name | Description
--- | ---
Id | 




CreateItem(T)
------


```
protected override async Task<T> CreateItem(T resource)
```

### Parameters
Name | Description
--- | ---
resource | 




DeleteItem(Guid)
------


```
protected override async Task DeleteItem(Guid Id) => await resources.DeleteOneAsync(r => r.Id == Id);
```

### Parameters
Name | Description
--- | ---
Id | 




UpdateItem(T)
------


```
protected override async Task<T> UpdateItem(T resource)
```

### Parameters
Name | Description
--- | ---
resource | 





