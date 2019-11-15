ResourceEventListener
======
> Namespace: ServiceBlock.Storage

Summary: Abstract class meant to be extended when creating resource event listeners.
  Parameters:
    T: The resource to listen to

```
public abstract class ResourceEventListener<T> where T : AbstractResource
```

## Constructors

ResourceEventListener(ILogger<ResourceEventListener<T>>, Storage<T>)
------


```
public ResourceEventListener(ILogger<ResourceEventListener<T>> logger, Storage<T> storage)
```

### Parameters
Name | Description
--- | ---
logger | 
storage | 








## Methods

OnCreate(T)
------
Summary: This method will be fired whenever a resource of type T is created
  Parameters:
    resource: The resource that was created

```
public virtual void OnCreate(T resource) => throw new NotImplementedException();
```

### Parameters
Name | Description
--- | ---
resource | 




OnUpdate(T)
------
Summary: This method will be fired whenever a resource of type T is updated
  Parameters:
    resource: The resource that was updated

```
public virtual void OnUpdate(T resource) => throw new NotImplementedException();
```

### Parameters
Name | Description
--- | ---
resource | 




OnDelete(T)
------
Summary: This method will be fired whenever a resource of type T is deleted
  Parameters:
    resource: The resource that was deleted

```
public virtual void OnDelete(T resource) => throw new NotImplementedException();
```

### Parameters
Name | Description
--- | ---
resource | 





