# ResourceEventListener

> Namespace: ServiceBlock.Messaging

```text
public abstract class ResourceEventListener<T> where T : AbstractResource
```

## ResourceEventListener\(ILogger&gt;, EventClient\)

```text
public ResourceEventListener(ILogger<ResourceEventListener<T>> logger, EventClient messageClient)
```

### Parameters

| Name | Description |
| :--- | :--- |
| logger |  |
| messageClient |  |

## ResourceEventListener\(ILogger&gt;, Storage\)

```text
public ResourceEventListener(ILogger<ResourceEventListener<T>> logger, Storage<T> storage)
```

### Parameters

| Name | Description |
| :--- | :--- |
| logger |  |
| storage |  |

## OnCreate\(T\)

```text
public virtual void OnCreate(T resource) => throw new NotImplementedException();
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource |  |

## OnUpdate\(T\)

```text
public virtual void OnUpdate(T resource) => throw new NotImplementedException();
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource |  |

## OnDelete\(T\)

```text
public virtual void OnDelete(T resource) => throw new NotImplementedException();
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource |  |

