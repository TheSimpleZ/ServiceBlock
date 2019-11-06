# ResourceTransformer

> Namespace: ServiceBlock.Interface.Resource

```text
public abstract class ResourceTransformer<T> where T : AbstractResource
```

## OnRead\(T\)

```text
public virtual Task<T> OnRead(T resource)
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource |  |

## OnCreate\(T\)

```text
public virtual Task<T> OnCreate(T resource)
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource |  |

## OnUpdate\(T\)

```text
public virtual Task<T> OnUpdate(T resource)
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource |  |

