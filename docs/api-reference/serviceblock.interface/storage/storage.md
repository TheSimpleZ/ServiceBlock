# Storage

> Namespace: ServiceBlock.Interface.Storage

Abstract storage class. Use this class to implement different types of storages for your resources.

```text
public abstract class Storage<T> where T : AbstractResource
```

## Storage\(ILogger&gt;, ResourceTransformer?\)

```text
protected Storage(ILogger<Storage<T>> logger, ResourceTransformer<T>? transformer = null)
```

### Parameters

| Name | Description |
| :--- | :--- |
| logger |  |
| transformer |  |

## Read\(Dictionary\)

```text
public async Task<IEnumerable<T>> Read(Dictionary<string, string> searchParams)
```

### Parameters

| Name | Description |
| :--- | :--- |
| searchParams |  |

## Read\(Guid\)

```text
public async Task<T> Read(Guid Id)
```

### Parameters

| Name | Description |
| :--- | :--- |
| Id |  |

## Create\(T\)

```text
public async Task<T> Create(T resource)
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource |  |

## Update\(T\)

```text
public async Task<T> Update(T resource)
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource |  |

## Delete\(Guid\)

```text
public async Task Delete(Guid Id)
```

### Parameters

| Name | Description |
| :--- | :--- |
| Id |  |

## ReadItems\(Dictionary\)

Get all items from database filtered by searchParams

```text
protected abstract Task<IEnumerable<T>> ReadItems(Dictionary<string, string> searchParams);
```

### Parameters

| Name | Description |
| :--- | :--- |
| searchParams | A dictionary mapping property name to expected value as a string |

**Returns:** All items of type T from the database

## ReadItem\(Guid\)

Get item from database by Id

```text
protected abstract Task<T> ReadItem(Guid Id);
```

### Parameters

| Name | Description |
| :--- | :--- |
| Id | The Id of the resource |

**Returns:** The requested resource

## CreateItem\(T\)

Create resource

```text
protected abstract Task<T> CreateItem(T resource);
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource | Resource to be created |

**Returns:** The created resource

## UpdateItem\(T\)

Update resource

```text
protected abstract Task<T> UpdateItem(T resource);
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource | New version of a resource |

**Returns:** The updated resource

## DeleteItem\(Guid\)

Delete resource

```text
protected abstract Task DeleteItem(Guid Id);
```

### Parameters

| Name | Description |
| :--- | :--- |
| Id | Id of resource to delete |

