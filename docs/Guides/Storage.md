# Storage

Any service providing CRUD operations is considered a storage service. In ServiceBlock all types of storage is implements the [Storage<T>](#Storage<T>) abstract class.

You can implement your own type of storage by implementing the [Storage<T>](#Storage<T>) abstract class.
Then ServiceBlock will recognize the storage when used in conjunction with the [storage attribute](#StorageAttribute).

## StorageAttribute

Every [Resource](./Resources) must have a storage associated with it.
To associate a storage type with a resource, use the `StorageAttribute`.

The `StorageAttribute` accepts a `Type` that implements the [Storage<T>](#Storage<T>) abstract class.

## Storage<T>

The `Storage<T>` abstract class defines the necessary functions for any storage to implement.

## Memory storage

Currently there is only one type of storage implemented, the memory storage. The memory storage holds all values in a dictionary, in memory. It's not persistent.
