# ServiceBlock

This library gives you a declarative approach to defining REST APIs. It's based on ASP.NET, but gives your a resource oriented workflow.

The purpose of this library is not to provide customizability.
Rather, it's to reduce a lot of the noise that comes with setting up a micro-service, allowing the developer to focus on writing business logic.

[Take a look in the wiki for a quick start guide!](https://github.com/TheSimpleZ/ServiceBlock/wiki)

**Since this library is still in early development APIs might change drastically until v2.0.0**

## Requirements

-   .Net Core 3.

## Features

-   Easy CRUD set up.
-   Easy to configure authentication.
-   Integrated Swagger UI with auto-generated OpenAPI specification.
-   Extensible interfaces for different types of messaging protocols, storages, etc.
-   Containerized and ready for the cloud.
-   Inter-service communication.
-   Subscribable APIs (internal only for now)

### Planned features

-   Service discovery.
-   Secret management.
-   Remote config with hot-reloading.
