This library gives you a declarative approach to defining REST APIs. It's based on ASP.NET, but gives your a resource oriented workflow.

The purpose of this library is to reduce a lot of the noise that comes with setting up a micro-service. Allowing the developer to focus on writing business logic.

{% hint style="warning" %}
Since this library is still in early development APIs might change drastically until v2.0.0
{% endhint %}

If you want to get started right away, check out the [Quick start guide](./Quickstart.md).

## Why?

A typical example of a simple controller for a CRUD API written in ASP.NET Core looks roughly like this:

```csharp

// The model
class Employee
{
    public Guid Id { get; set; }
}


[ApiController]
[Route("[controller]")]
class EmployeeController : ControllerBase
{
    private readonly Storage<Employee> _storage;

    public EmployeeController(Storage<Employee> storage)
    {
        _logger = logger;
        _storage = storage;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> Get()
    {
        return Ok(await _storage.Read());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Employee>> Get([FromRoute] Guid Id)
    {
        return Ok(await _storage.Read(Id));
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> Post([FromBody]Employee resource)
    {
        await _storage.Create(resource);
        return Ok();
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<Employee>> Put([FromRoute]Guid Id, [FromBody]Employee resource)
    {
        await _storage.Update(Id, resource);
        return Ok();
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<Employee>> Delete([FromRoute]Guid Id)
    {
        await _storage.Delete(Id);
        return Ok();
    }
}
```

{% hint style="info" %}
The above code does not implement any security features, validation or error handling.
{% endhint %}

Then there is at least equal amounts of code going into implementing the storage, security, documentation and all other things.
However, most of these aspects can be generically programmed, allowing the developer to simply fill in the blanks as needed.

By following standards such as REST, OpenAPI and OAuth we can reduce the code needed to get a CRUD API going to:

```csharp
[Storage(typeof(MemoryStorage<>))]
public class Employee : AbstractResource
{ }
```

Once the resource have been defined, the ServiceBlock framework will generate a CRUD API at `http://localhost:5001/Employee` with a ReDoc page at `http://localhost:5001/`. The resource will be stored in memory as defined by the storage attribute. Validation and error handling has default behaviors in place.

The same goes for most things not tied to business logic. For example, by standardizing the implementation of storages, people can simply define the storage place for a resource using an attribute.

To see all of the features please read through [the guides](./guides).

## How do we do it?

We use a technique called assembly scanning to register generic implementations of controllers, storages, messaging clients etc.
By looking for the classes and attributes you've defined ServiceBlock will know what storage to use for which type of resource.

# Requirements

-   .Net Core 3

# Features

-   OpenAPI documentation with ReDoc UI.
-   [Automatic CRUD API setup.](./guides/resources.md)
-   [Easy to configure authentication.](./guides/authentication.md)
-   [Containerized and ready for the cloud.](./deployment.md)
-   [Subscribable APIs \(internal only for now\)](./guides/messaging/resourceeventlisteners.md)

## [Storages](./guides/storage.md)

-   Internal memory storage
-   MongoDB storage

## [Messaging queues](./guides/messaging/README.md)

-   RabbitMQ

# Planned features

-   Service discovery.
-   Secret management.
-   Remote config with hot-reloading.

![Pack and publish dotnet core library](https://github.com/TheSimpleZ/ServiceBlock/workflows/Pack%20and%20publish%20dotnet%20core%20library/badge.svg)
[![codecov](https://codecov.io/gh/TheSimpleZ/ServiceBlock/branch/master/graph/badge.svg)](https://codecov.io/gh/TheSimpleZ/ServiceBlock)
