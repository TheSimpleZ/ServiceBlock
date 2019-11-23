# Storage

> Namespace: ServiceBlock.Interface.Storage

Abstract storage class. Use this class to implement different types of storages for your resources.

```text
public abstract class Storage<T> where T : AbstractResource
```

## Constructors

## Storage\(ILogger&gt;\)

```csharp
protected Storage(ILogger<Storage<T>> logger)
```

## Methods

### Read\(Dictionary\)

```csharp
public async Task<IEnumerable<T>> Read(Dictionary<string, string> searchParams)
```

### Read\(Guid\)

```csharp
public async Task<T> Read(Guid Id)
```

### Create\(T\)

```csharp
public async Task<T> Create(T resource)
```

### Update\(T\)

```csharp
public async Task<T> Update(T resource)
```

### Delete\(Guid\)

```csharp
public async Task Delete(Guid Id)
```

### ReadItems\(Dictionary\)

Get all items from database filtered by searchParams

```csharp
protected abstract Task<IEnumerable<T>> ReadItems(Dictionary<string, string> searchParams);
```

### Parameters

| Name | Description |
| :--- | :--- |
| searchParams | A dictionary mapping property name to expected value as a string |

**Returns:** All items of type T from the database

### ReadItem\(Guid\)

Get item from database by Id

```csharp
protected abstract Task<T> ReadItem(Guid Id);
```

### Parameters

| Name | Description |
| :--- | :--- |
| Id | The Id of the resource |

**Returns:** The requested resource

### CreateItem\(T\)

Create resource

```csharp
protected abstract Task<T> CreateItem(T resource);
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource | Resource to be created |

**Returns:** The created resource

### UpdateItem\(T\)

Update resource

```csharp
protected abstract Task<T> UpdateItem(T resource);
```

### Parameters

| Name | Description |
| :--- | :--- |
| resource | New version of a resource |

**Returns:** The updated resource

### DeleteItem\(Guid\)

Delete resource

```csharp
protected abstract Task DeleteItem(Guid Id);
```

### Parameters

| Name | Description |
| :--- | :--- |
| Id | Id of resource to delete |

