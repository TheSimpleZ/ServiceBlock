# BlockInfo

> Namespace: ServiceBlock.Interface

This class provides methods to easily access a Blocks properties.

```text
public static class BlockInfo
```

## Properties

### Name

Name of the current service

```csharp
public static string? Name => Assembly.GetEntryAssembly()?.GetName().Name;
```

### ResourceTypes

All resources defined in the current service and the ServiceBlock Framework

```csharp
public static IEnumerable<Type> ResourceTypes => BlockTypes.Where(x => typeof(AbstractResource).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);
```

### ServiceConfigurators

```csharp
public static IEnumerable<IServiceConfiguration> ServiceConfigurators =>
BlockTypes
.Where(t => t.IsClass && typeof(IServiceConfiguration).IsAssignableFrom(t))
.Select(Activator.CreateInstance)
.Cast<IServiceConfiguration>();
```

### BlockTypes

```csharp
public static IEnumerable<Type> BlockTypes =>
Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.AllDirectories)
.Where(f => isServiceBlockAssembly(Path.GetFileNameWithoutExtension(f)))
.SelectMany(dll =>
```

