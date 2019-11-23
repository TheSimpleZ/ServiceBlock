ResourceEventListener
======
> Namespace: ServiceBlock.Storage

Abstract class meant to be extended when creating resource event listeners.

```
public abstract class ResourceEventListener<T> where T : AbstractResource
```

### Parameters

Name | Description
--- | ---
T | The resource to listen to


## Constructors

ResourceEventListener(ILogger<ResourceEventListener<T>>, Storage<T>)
------


```
public ResourceEventListener(ILogger<ResourceEventListener<T>> logger, Storage<T> storage)
```




## Methods

###OnCreate(T)

This method will be fired whenever a resource of type T is created

```
public virtual void OnCreate(T resource) => throw new NotImplementedException();
```

### Parameters

Name | Description
--- | ---
resource | The resource that was created




###OnUpdate(T)

This method will be fired whenever a resource of type T is updated

```
public virtual void OnUpdate(T resource) => throw new NotImplementedException();
```

### Parameters

Name | Description
--- | ---
resource | The resource that was updated




###OnDelete(T)

This method will be fired whenever a resource of type T is deleted

```
public virtual void OnDelete(T resource) => throw new NotImplementedException();
```

### Parameters

Name | Description
--- | ---
resource | The resource that was deleted




