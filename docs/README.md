# ServiceBlock

This library gives you a declarative approach to defining REST APIs. It's based on ASP.NET, but gives your a resource oriented workflow.

The purpose of this library is not to provide customizability. Rather, it's to reduce a lot of the noise that comes with setting up a micro-service, allowing the developer to focus on writing business logic.

**Since this library is still in early development APIs might change drastically until v2.0.0**

## Requirements

* .Net Core 3

## Features

* Easy CRUD set up.
* [Easy to configure authentication.](guides/authentication.md)
* Integrated Swagger UI with auto-generated OpenAPI specification.
* Extensible interfaces for different types of messaging protocols, storages, etc.
* [Containerized and ready for the cloud.](https://github.com/TheSimpleZ/ServiceBlock/tree/02c3c5f8089399df692e8433b69a012161f7fc37/docs/guides/deployment/README.md)
* [Subscribable APIs \(internal only for now\)](https://github.com/TheSimpleZ/ServiceBlock/tree/02c3c5f8089399df692e8433b69a012161f7fc37/docs/guides/messaging/resourceeventlisteners/README.md)

### Planned features

* Service discovery.
* Secret management.
* Remote config with hot-reloading.

[![codecov](https://codecov.io/gh/TheSimpleZ/ServiceBlock/branch/master/graph/badge.svg)](https://codecov.io/gh/TheSimpleZ/ServiceBlock)

