ResourceEventListener
======
> Namespace: ServiceBlock.Messaging



```
public abstract class ResourceEventListener<T> where T : AbstractResource
```

## Constructors

ResourceEventListener(ILogger<ResourceEventListener<T>>, EventClient)
------


```
public ResourceEventListener(ILogger<ResourceEventListener<T>> logger, EventClient messageClient)
```




ResourceEventListener(ILogger<ResourceEventListener<T>>, Storage<T>)
------


```
public ResourceEventListener(ILogger<ResourceEventListener<T>> logger, Storage<T> storage)
```




## Methods

OnCreate(T)
------


```
public virtual void OnCreate(T resource) => throw new NotImplementedException();
```





OnUpdate(T)
------


```
public virtual void OnUpdate(T resource) => throw new NotImplementedException();
```





OnDelete(T)
------


```
public virtual void OnDelete(T resource) => throw new NotImplementedException();
```





