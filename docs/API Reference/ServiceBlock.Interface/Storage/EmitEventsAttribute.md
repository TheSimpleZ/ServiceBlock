EmitEventsAttribute
======
> Namespace: ServiceBlock.Interface.Storage



```
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class EmitEventsAttribute : Attribute
```

## Constructors

EmitEventsAttribute(ResourceEventType[])
------
This attribute can be used on a resource to make it emit certain types of events. Defaults to all types

```
public EmitEventsAttribute(params ResourceEventType[] eventTypes)
```

### Parameters

Name | Description
--- | ---
eventTypes | The types of events that should be emitted



## Properties

###EventTypes



```
public IEnumerable<ResourceEventType> EventTypes
```


