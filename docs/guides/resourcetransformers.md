# Resource transformers

Sometimes you might want to modify a resource before it's read/written to the storage.

The `ResourceTransformer<T>` class allows you to listen for any CRU operations performed on a resource `T`. The transformer has 4 virtual functions which you can override to act on the corresponding events.

* `Task<T> OnGet(T resource)`
* `Task<T> OnCreate(T resource)`
* `Task<T> OnUpdate(T resource)`

All read operation events are fired **after** the resource is retrieved from storage. The return value will be returned to the caller.

All write operation events are fired **before** the resource is sent to storage. The return value will be the value that's stored.

