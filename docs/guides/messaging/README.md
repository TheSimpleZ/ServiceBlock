# Messaging

The messaging package enables you to emit resource events for any resource you have defined in your service. The events will be emitted by the associated `Storage<T>` class.

By default, there's also a RabbitMQ EventClient registered that will publish any events emitted by the store to the configured RabbitMQ client.

Any [ResourceEventListener](./resourceeventlisteners.md) defined for your resource will pick up and handle these events, even if they are in other services.

## Installation

To enable Messaging simply install the NuGet package:

```text
dotnet add package ServiceBlock.Messaging
```

The RabbitMQ client expects a connection string provided in the appsettings.json under the key `RabbitMq`. Alternatively set the environment variable `ASPNETCORE_ConnectionStrings__RabbitMq`.

## Emit events

To emit events apply the `EmitEvents` attribute to the resource you would like to emit events for. You can also choose specific events to emit by supplying any combinations of `ResourceEventType` enums to the constructor.

**Example:**

```csharp
[Storage(typeof(MemoryStorage<>))]
[EmitEvents ]
public class Invoice : AbstractResource
{
    public string InvoiceNumber { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow();
}
```
