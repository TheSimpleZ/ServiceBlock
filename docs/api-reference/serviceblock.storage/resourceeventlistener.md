# ResourceEventListener

> Namespace: ServiceBlock.Storage

Abstract class meant to be extended when creating resource event listeners.

```text
public abstract class ResourceEventListener<T> where T : AbstractResource
```

### Parameters

| Name | Description |
| :--- | :--- |
| T | The resource to listen to |

## Constructors

## ResourceEventListener\(ILogger&gt;, Storage\)

```csharp
public ResourceEventListener(ILogger<ResourceEventListener<T>> logger, Storage<T> storage)
```

## Methods

### OnCreate\(T\)

This method will be fired whenever a resource of type T is created

```csharp
public virtual void OnCreate(T resource) => throw new NotImplementedException();
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource | The resource that was created |

### OnUpdate\(T\)

This method will be fired whenever a resource of type T is updated

```csharp
public virtual void OnUpdate(T resource) => throw new NotImplementedException();
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource | The resource that was updated |

### OnDelete\(T\)

This method will be fired whenever a resource of type T is deleted

```csharp
public virtual void OnDelete(T resource) => throw new NotImplementedException();
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource | The resource that was deleted |

