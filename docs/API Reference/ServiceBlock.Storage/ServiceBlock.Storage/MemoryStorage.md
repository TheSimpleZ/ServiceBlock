MemoryStorage
======
##### Namespace: ServiceBlock.Storage




```
public class MemoryStorage<T> : Storage<T> where T : AbstractResource
```


MemoryStorage(ILogger<MemoryStorage<T>>, ResourceTransformer<T>?)
------

```
public MemoryStorage(ILogger<MemoryStorage<T>> logger, ResourceTransformer<T>? transformer = null) : base(logger, transformer)
```
### Parameters
Name | Description
--- | ---
logger | 
transformer | 





ReadItems(Dictionary<string, string>)
------

```
protected override Task<IEnumerable<T>> ReadItems(Dictionary<string, string> searchParams)
```
### Parameters
Name | Description
--- | ---
searchParams | 




ReadItem(Guid)
------

```
protected override Task<T> ReadItem(Guid Id)
```
### Parameters
Name | Description
--- | ---
Id | 




CreateItem(T)
------

```
protected override Task<T> CreateItem(T resource)
```
### Parameters
Name | Description
--- | ---
resource | 




DeleteItem(Guid)
------

```
protected override Task DeleteItem(Guid Id)
```
### Parameters
Name | Description
--- | ---
Id | 




UpdateItem(T)
------

```
protected override Task<T> UpdateItem(T resource)
```
### Parameters
Name | Description
--- | ---
resource | 




