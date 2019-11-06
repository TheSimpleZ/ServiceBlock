Block
======
###### Namespace: ServiceBlock.Core




```
public static class Block
```




Controllers
------

```
public static IEnumerable<TypeInfo> Controllers => GetResourceController(readOnly: true).Concat(GetResourceController());
```



Run(string[], Logger?)
------

```
public static void Run(string[] args, Logger? logger = null)
```
### Parameters
Name | Description
--- | ---
args | 
logger | 




