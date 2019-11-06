# Block

> Namespace: ServiceBlock.Core

```text
public static class Block
```

## Controllers

```text
public static IEnumerable<TypeInfo> Controllers => GetResourceController(readOnly: true).Concat(GetResourceController());
```

## Run\(string\[\], Logger?\)

```text
public static void Run(string[] args, Logger? logger = null)
```

### Parameters

| Name | Description |
| :--- | :--- |
| args |  |
| logger |  |

