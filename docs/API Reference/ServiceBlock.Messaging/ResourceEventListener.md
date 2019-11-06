ResourceEventListener
======
###### Namespace: ServiceBlock.Messaging




```
public abstract class ResourceEventListener<T> where T : AbstractResource
```


ResourceEventListener(ILogger<ResourceEventListener<T>>, EventClient)
------

```
public ResourceEventListener(ILogger<ResourceEventListener<T>> logger, EventClient messageClient)
```
### Parameters
Name | Description
--- | ---
logger | 
messageClient | 


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





OnCreate(T)
------

```
public virtual void OnCreate(T resource) => throw new NotImplementedException();
```
### Parameters
Name | Description
--- | ---
resource | 




OnUpdate(T)
------

```
public virtual void OnUpdate(T resource) => throw new NotImplementedException();
```
### Parameters
Name | Description
--- | ---
resource | 




OnDelete(T)
------

```
public virtual void OnDelete(T resource) => throw new NotImplementedException();
```
### Parameters
Name | Description
--- | ---
resource | 




