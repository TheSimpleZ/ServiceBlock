# EmitEventsAttribute

> Namespace: ServiceBlock.Interface.Storage

```text
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
```

## EmitEventsAttribute\(ResourceEventType\[\]\)

```text
public EmitEventsAttribute(params ResourceEventType[] eventTypes)
```

### Parameters

| Name | Description |
| :--- | :--- |
| eventTypes |  |

## EventTypes

```text
public IEnumerable<ResourceEventType> EventTypes { get; private set; }
```

