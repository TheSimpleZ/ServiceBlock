# Storage

Any service providing CRUD operations is considered a storage service. In ServiceBlock all types of storage is implements the [Storage](storage.md#Storage%3CT%3E) abstract class.

You can implement your own type of storage by implementing the [Storage](storage.md#Storage%3CT%3E) abstract class. Then ServiceBlock will recognize the storage when used in conjunction with the [storage attribute](storage.md#StorageAttribute).

## StorageAttribute

Every [Resource](resources.md) must have a storage associated with it. To associate a storage type with a resource, use the `StorageAttribute`.

The `StorageAttribute` accepts a `Type` that implements the [Storage](storage.md#Storage%3CT%3E) abstract class.

## Storage

The `Storage<T>` abstract class defines the necessary functions for any storage to implement.

## Memory storage

The memory storage holds all values in a dictionary, in memory. It's not persistent.

## MongoDB storage

The MongoDB storage can be used to save resources in MongoDB. You must provide a connection string using the `ConnectionStrings` configuration value in appsettings.json.

```javascript
{
    "ConnectionStrings": {
        "MongoDB": "YOUR_CONNECTION_STRING"
    }
}
```

