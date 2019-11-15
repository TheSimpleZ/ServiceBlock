Storage
======
> Namespace: ServiceBlock.Interface.Storage

Abstract storage class.
Use this class to implement different types of storages for your resources.

```
public abstract class Storage<T> where T : AbstractResource
```

## Constructors

Storage(ILogger<Storage<T>>, ResourceTransformer<T>?)
------


```
protected Storage(ILogger<Storage<T>> logger, ResourceTransformer<T>? transformer = null)
```

### Parameters
Name | Description
--- | ---
logger | 
transformer | 








## Methods

Read(Dictionary<string, string>)
------


```
public async Task<IEnumerable<T>> Read(Dictionary<string, string> searchParams)
```

### Parameters
Name | Description
--- | ---
searchParams | 




Read(Guid)
------


```
public async Task<T> Read(Guid Id)
```

### Parameters
Name | Description
--- | ---
Id | 




Create(T)
------


```
public async Task<T> Create(T resource)
```

### Parameters
Name | Description
--- | ---
resource | 




Update(T)
------


```
public async Task<T> Update(T resource)
```

### Parameters
Name | Description
--- | ---
resource | 




Delete(Guid)
------


```
public async Task Delete(Guid Id)
```

### Parameters
Name | Description
--- | ---
Id | 




ReadItems(Dictionary<string, string>)
------
Get all items from database filtered by searchParams

```
protected abstract Task<IEnumerable<T>> ReadItems(Dictionary<string, string> searchParams);
```

### Parameters
Name | Description
--- | ---
searchParams | A dictionary mapping property name to expected value as a string

**Returns:** All items of type T from the database


ReadItem(Guid)
------
Get item from database by Id

```
protected abstract Task<T> ReadItem(Guid Id);
```

### Parameters
Name | Description
--- | ---
Id | The Id of the resource

**Returns:** The requested resource


CreateItem(T)
------
Create resource

```
protected abstract Task<T> CreateItem(T resource);
```

### Parameters
Name | Description
--- | ---
resource | Resource to be created

**Returns:** The created resource


UpdateItem(T)
------
Update resource

```
protected abstract Task<T> UpdateItem(T resource);
```

### Parameters
Name | Description
--- | ---
resource | New version of a resource

**Returns:** The updated resource


DeleteItem(Guid)
------
Delete resource

```
protected abstract Task DeleteItem(Guid Id);
```

### Parameters
Name | Description
--- | ---
Id | Id of resource to delete





