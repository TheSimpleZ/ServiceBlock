Block
======
> Namespace: ServiceBlock.Core



```
public static class Block
```

## Properties

###Controllers



```
public static IEnumerable<TypeInfo> Controllers => GetResourceController(readOnly: true).Concat(GetResourceController());
```


## Methods

###Run(string[], Logger?)



```
public static void Run(string[] args, Logger? logger = null)
```





