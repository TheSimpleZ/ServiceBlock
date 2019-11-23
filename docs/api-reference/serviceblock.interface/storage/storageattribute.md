# StorageAttribute

> Namespace: ServiceBlock.Interface.Storage

```text
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class StorageAttribute : Attribute
```

## Constructors

## StorageAttribute\(Type\)

This attribute should be used to mark the storage type of a resource

```csharp
public StorageAttribute(Type storageType)
```

### Parameters

| Name | Description |
| :--- | :--- |
| storageType | The type of storage that should be used |

## Properties

### StorageType

```csharp
public Type StorageType
```

