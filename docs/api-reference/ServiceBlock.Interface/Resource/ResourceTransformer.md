ResourceTransformer
======
> Namespace: ServiceBlock.Interface.Resource



```
public abstract class ResourceTransformer<T> where T : AbstractResource
```









## Methods

OnRead(T)
------


```
public virtual Task<T> OnRead(T resource)
```

### Parameters
Name | Description
--- | ---
resource | 




OnCreate(T)
------


```
public virtual Task<T> OnCreate(T resource)
```

### Parameters
Name | Description
--- | ---
resource | 




OnUpdate(T)
------


```
public virtual Task<T> OnUpdate(T resource)
```

### Parameters
Name | Description
--- | ---
resource | 





