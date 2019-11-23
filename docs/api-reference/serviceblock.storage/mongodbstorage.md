# MongoDbStorage

> Namespace: ServiceBlock.Storage

ServiceBlock storage backed by mongo db.

```text
public class MongoDbStorage<T> : Storage<T> where T : AbstractResource
```

### Parameters

| Name | Description |
| :--- | :--- |
| T | The resource type |

## Constructors

## MongoDbStorage\(ILogger&gt;, IConfiguration, IOptionsMonitor\)

```csharp
public MongoDbStorage(ILogger<MemoryStorage<T>> logger, IConfiguration config, IOptionsMonitor<MongoDb> options) : base(logger)
```

## Methods

### ReadItems\(Dictionary\)

```csharp
protected override async Task<IEnumerable<T>> ReadItems(Dictionary<string, string> searchParams)
```

### ReadItem\(Guid\)

```csharp
protected override async Task<T> ReadItem(Guid Id)
```

### CreateItem\(T\)

```csharp
protected override async Task<T> CreateItem(T resource)
```

### DeleteItem\(Guid\)

```csharp
protected override async Task DeleteItem(Guid Id) => await resources.DeleteOneAsync(r => r.Id == Id);
```

### UpdateItem\(T\)

```csharp
protected override async Task<T> UpdateItem(T resource)
```

