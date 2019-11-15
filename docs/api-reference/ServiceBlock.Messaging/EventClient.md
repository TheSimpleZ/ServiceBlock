EventClient
======
> Namespace: ServiceBlock.Messaging



```
public abstract class EventClient
```

## Constructors

EventClient(ILogger<EventClient>)
------


```
protected EventClient(ILogger<EventClient> logger)
```

### Parameters
Name | Description
--- | ---
logger | 








## Methods

Publish(ResourceEventType, T)
------


```
public abstract void Publish<T>(ResourceEventType type, T payload);
```

### Parameters
Name | Description
--- | ---
type | 
payload | 




OnMessageReceived(ResourceEventArgs)
------


```
protected virtual void OnMessageReceived(ResourceEventArgs args)
```

### Parameters
Name | Description
--- | ---
args | 





