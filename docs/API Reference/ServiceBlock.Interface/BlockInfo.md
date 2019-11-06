BlockInfo
======
> Namespace: ServiceBlock.Interface




```
public static class BlockInfo
```




Name
------

```
public static string? Name => Assembly.GetEntryAssembly()?.GetName().Name;
```


ResourceTypes
------

```
public static IEnumerable<Type> ResourceTypes => BlockTypes.Where(x => typeof(AbstractResource).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);
```


ServiceConfigurators
------

```
public static IEnumerable<IServiceConfiguration> ServiceConfigurators =>
```


BlockTypes
------

```
public static IEnumerable<Type> BlockTypes =>
```




