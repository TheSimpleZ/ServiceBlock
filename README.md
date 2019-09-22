# ServiceBlock

This library gives you a declarative approach to defining REST APIs. It's based on ASP.NET, but gives your a resource oriented workflow.

The purpose of this library is not to provide customizability.
Rather, it's to reduce a lot of the noise that comes with setting up a micro-service, allowing the developer to focus on writing business logic.

## Installation

You can either choose to use our template to scaffold a new project, or you can install the library and migrate your current structure to ServiceBlock.

### Quick start

The dotnet CLI comes with build in scaffolding tools. We provide a package containing useful templates for creating ServiceBlocks.

To install all templates, run:

```
dotnet new -i ServiceBlock.Templates
```

#### Create a ServiceBlock service

```
mkdir <YOUR_PROJECT_NAME> && cd <YOUR_PROJECT_NAME>
dotnet new serviceblock
```

### Migrate existing project

Migrate from ASP.NET:

```
dotnet add package ServiceBlock
```

Then go to your Program.cs and call `ServiceBlock.Startup.Block.Run(args)` from your main function.

Create a new project called `<YOUR_PROJECT_NAME>.Interface`. This project will contain the public interface of your service. Now you can start defining resources.

## Guide

The framework can be used to easily define resources in your REST API. To define a resource simply inherit from the `AbstractResource` class.
For each class that inherits from `AbstractResource` the framework will create a GetAll, Get, Post, Put and Delete endpoint.
The `AbstractResource` class has an ID property that will be inherited by all resources.

### Authentication

To add authentication to the service, simply provide the following json in you appsettings.json.

```
"ServiceBlock": {
    "Security": {
        "Domain": "https://<YOUR_IDP_URL>/",
        "ApiIdentifier": "<YOUR_API_ID>",
        "ClientId": "<YOUR_CLIENT_ID>",
        "Scopes": {
            "email": "Example Scope"
        }
    }
}
```

Authentication will be activated for all your resources.

### Resources

Here's an example of an Invoice resource:

```CSharp
public class Invoice : AbstractResource
{
    public string InvoiceNumber { get; set; }
}
```

This class is not fully functional though, since it does not have any type of storage attached to it.

To add storage to a resource, you should use the `StorageAttribute`. To add a simple Memory storage to our Invoice resource you simply add the attribute like this:

```CSharp
[Storage(typeof(MemoryStorage<Invoice>))]
public class Invoice : AbstractResource
{
    public string InvoiceNumber { get; set; }
}
```

Now, when you run your web app, you'll see a swagger page with all the CRUD endpoints for our Invoice resource.

#### The ReadOnly attribute

Sometimes you might want to have a property which can be read, but not modified through the API, for example the date a resource was created.
To achieve this, you can use the `ReadOnlyAttribute` from `System.ComponentModel`.
When you use the `ReadOnlyAttribute` you must also define a default value for when a resource is created.
Below is an example of adding created-date to our Invoice resource.

```CSharp
[Storage(typeof(MemoryStorage<Invoice>))]
public class Invoice : AbstractResource
{
    public string InvoiceNumber { get; set; }

    [ReadOnly(true)]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow();
}
```

### Resource event listeners

Sometimes you might want to perform certain action when a resource is created, read, updated or deleted. Or you might want to modify the resource before it's read/written to the storage.

The `ResourceEventListener<T>` class allows you to listen for any CRUD operations performed on a resource `T`. The event listener has 4 virtual functions which you can override to listen to the corresponding events.

-   `Task<IEnumerable<T>> OnGet(IEnumerable<T> resources)`
-   `Task<T> OnGet(T resource)`
-   `Task<T> OnCreate(T resource)`
-   `Task<T> OnReplace(T resource)`
-   `Task OnDelete(Guid Id)`

All read operation events are fired **after** the resource is retrieved from storage. The return value will be returned to the caller.

All write operation events are fired **before** the resource is sent to storage. The return value will be the value that's stored.

### Health checks

A basic health check endpoint has been implemented at `/health`.

## Deploy API

The application is meant to be run as a docker container. To build the container, simply run:

```
dotnet build -c Release
docker build -t InvoiceService .
docker run --rm -it -p 8080:80 InvoiceService
```

Now open your web browser an navigate to `http://localhost:8080`.
