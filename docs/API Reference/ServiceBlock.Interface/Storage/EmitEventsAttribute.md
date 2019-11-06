EmitEventsAttribute
======
> Namespace: ServiceBlock.Interface.Storage




```
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
```


EmitEventsAttribute(ResourceEventType[])
------

```
public EmitEventsAttribute(params ResourceEventType[] eventTypes)
```
### Parameters
Name | Description
--- | ---
eventTypes | 



EventTypes
------

```
public IEnumerable<ResourceEventType> EventTypes { get; private set; }
```




