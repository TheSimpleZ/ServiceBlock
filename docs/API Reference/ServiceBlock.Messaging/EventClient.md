EventClient
======
> Namespace: ServiceBlock.Messaging



```
public abstract class EventClient
```

## Constructors

EventClient(ILogger<EventClient>)
------


```csharp
protected EventClient(ILogger<EventClient> logger)
```




## Methods

### Publish(ResourceEventType, T)



```csharp
public abstract void Publish<T>(ResourceEventType type, T payload);
```





### OnMessageReceived(ResourceEventArgs)



```csharp
protected virtual void OnMessageReceived(ResourceEventArgs args)
```





