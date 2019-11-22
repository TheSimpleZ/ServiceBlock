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




## Methods

Publish(ResourceEventType, T)
------


```
public abstract void Publish<T>(ResourceEventType type, T payload);
```





OnMessageReceived(ResourceEventArgs)
------


```
protected virtual void OnMessageReceived(ResourceEventArgs args)
```





