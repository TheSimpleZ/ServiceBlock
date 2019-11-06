# EventClient

> Namespace: ServiceBlock.Messaging

```text
public abstract class EventClient
```

## EventClient\(ILogger\)

```text
protected EventClient(ILogger<EventClient> logger)
```

### Parameters

| Name | Description |
| :--- | :--- |
| logger |  |

## Publish\(ResourceEventType, T\)

```text
public abstract void Publish<T>(ResourceEventType type, T payload);
```

### Parameters

| Name | Description |
| :--- | :--- |
| type |  |
| payload |  |

## OnMessageReceived\(ResourceEventArgs\)

```text
protected virtual void OnMessageReceived(ResourceEventArgs args)
```

### Parameters

| Name | Description |
| :--- | :--- |
| args |  |

