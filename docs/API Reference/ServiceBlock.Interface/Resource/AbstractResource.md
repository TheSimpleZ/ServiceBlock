AbstractResource
======
> Namespace: ServiceBlock.Interface.Resource

This class describes resources in the service.
To create a resource, you must extend this class.

```
public abstract class AbstractResource
```

## Properties

### Id

This parameter is used to identify the resource in the API.
If overridden, you must ensure uniqueness.

```csharp
[ReadOnly(true)]
public virtual Guid Id
```


## Methods

### OnRead()

This method will be fired after the resource has been retrieved from storage, but before it's returned to the client.

```csharp
public virtual Task OnRead() => Task.CompletedTask;
```





### OnCreate()

This method will be fired after the resource has been received from the API, but before it's written to the storage.

```csharp
public virtual Task OnCreate() => Task.CompletedTask;
```





### OnUpdate()

This method will be fired after the resource has been received from the API, but before it's written to the storage.

```csharp
public virtual Task OnUpdate() => Task.CompletedTask;
```





