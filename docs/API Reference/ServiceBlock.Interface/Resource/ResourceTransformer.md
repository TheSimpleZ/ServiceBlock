ResourceTransformer
======
> Namespace: ServiceBlock.Interface.Resource

This class can be extended to transform a resource before it's read/written

```
public abstract class ResourceTransformer<T> where T : AbstractResource
```

### Parameters

Name | Description
--- | ---
T | The type of resource to transform


## Methods

### OnRead(T)

This method will be fired after the resource has been retrieved from storage, but before it's returned to the client.

```csharp
public virtual Task<T> OnRead(T resource)
```

### Parameters

Name | Description
--- | ---
resource | The resource that was retrieved from storage

**Returns:** The item to be returned to the client.


### OnCreate(T)

This method will be fired after the resource has been received from the API, but before it's written to the storage.

```csharp
public virtual Task<T> OnCreate(T resource)
```

### Parameters

Name | Description
--- | ---
resource | The resource that was received from the API

**Returns:** The item to be written to storage.


### OnUpdate(T)

This method will be fired after the resource has been received from the API, but before it's written to the storage.

```csharp
public virtual Task<T> OnUpdate(T resource)
```

### Parameters

Name | Description
--- | ---
resource | The resource that was received from the API

**Returns:** The item to be written to storage.


