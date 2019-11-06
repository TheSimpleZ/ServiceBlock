# BlockInfo

> Namespace: ServiceBlock.Interface

```text
public static class BlockInfo
```

## Name

```text
public static string? Name => Assembly.GetEntryAssembly()?.GetName().Name;
```

## ResourceTypes

```text
public static IEnumerable<Type> ResourceTypes => BlockTypes.Where(x => typeof(AbstractResource).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);
```

## ServiceConfigurators

```text
public static IEnumerable<IServiceConfiguration> ServiceConfigurators =>
```

## BlockTypes

```text
public static IEnumerable<Type> BlockTypes =>
```

