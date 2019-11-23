ResourceEventListener
======
> Namespace: ServiceBlock.Messaging



```
public abstract class ResourceEventListener<T> where T : AbstractResource
```

## Constructors

ResourceEventListener(ILogger<ResourceEventListener<T>>, EventClient)
------


```csharp
public ResourceEventListener(ILogger<ResourceEventListener<T>> logger, EventClient messageClient)
```




ResourceEventListener(ILogger<ResourceEventListener<T>>, Storage<T>)
------


```csharp
public ResourceEventListener(ILogger<ResourceEventListener<T>> logger, Storage<T> storage)
```




## Methods

### OnCreate(T)



```csharp
public virtual void OnCreate(T resource) => throw new NotImplementedException();
```





### OnUpdate(T)



```csharp
public virtual void OnUpdate(T resource) => throw new NotImplementedException();
```





### OnDelete(T)



```csharp
public virtual void OnDelete(T resource) => throw new NotImplementedException();
```





