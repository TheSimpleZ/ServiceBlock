# Resource event listeners

Sometimes you might want to perform certain action when a resource is created, updated or deleted.

The `ResourceEventListener<T>` class allows you to listen for any CUD operations performed on a resource `T`. The event listener has 4 virtual functions which you can override to listen to the corresponding events.

- `void OnCreate(T resource)`
- `void OnUpdate(T resource)`
- `void OnDelete(Guid Id)`

## Namespaces

There are 2 types of resource event listeners. Once exists in the Messaging package and allows you to listen to events from remote services.
The other is in the Storage package and allows you to listen to events from local resources.
