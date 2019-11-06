# MemoryStorage

> Namespace: ServiceBlock.Storage

```text
public class MemoryStorage<T> : Storage<T> where T : AbstractResource
```

## MemoryStorage\(ILogger&gt;, ResourceTransformer?\)

```text
public MemoryStorage(ILogger<MemoryStorage<T>> logger, ResourceTransformer<T>? transformer = null) : base(logger, transformer)
```

### Parameters

| Name | Description |
| :--- | :--- |
| logger |  |
| transformer |  |

## ReadItems\(Dictionary\)

```text
protected override Task<IEnumerable<T>> ReadItems(Dictionary<string, string> searchParams)
```

### Parameters

| Name | Description |
| :--- | :--- |
| searchParams |  |

## ReadItem\(Guid\)

```text
protected override Task<T> ReadItem(Guid Id)
```

### Parameters

| Name | Description |
| :--- | :--- |
| Id |  |

## CreateItem\(T\)

```text
protected override Task<T> CreateItem(T resource)
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource |  |

## DeleteItem\(Guid\)

```text
protected override Task DeleteItem(Guid Id)
```

### Parameters

| Name | Description |
| :--- | :--- |
| Id |  |

## UpdateItem\(T\)

```text
protected override Task<T> UpdateItem(T resource)
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource |  |

