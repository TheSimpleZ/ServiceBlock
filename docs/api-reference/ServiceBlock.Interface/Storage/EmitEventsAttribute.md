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


```
public EmitEventsAttribute(params ResourceEventType[] eventTypes)
```

### Parameters
Name | Description
--- | ---
eventTypes | 




## Properties

EventTypes
------


```
public IEnumerable<ResourceEventType> EventTypes
```







