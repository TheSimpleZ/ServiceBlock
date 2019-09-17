# ServiceBlock

This library gives you a declarative approach to defining REST APIs.

## Installation

You can either choose to use our template to scaffold a new project, or you can install the library and migrate your current structure to ServiceBlock.

### Quick start

Use [ServiceBlock.Sample](https://github.com/TheSimpleZ/ServiceBlock.Sample) to scaffold new projects.

### Migrate existing project

Migrate from ASP.NET:

```
dotnet add package ServiceBlock
```

Then go to your Program.cs and call `ServiceBlock.Startup.Block.Run(args)`. Now you can start defining resources.

## Usage

The framework can be used to easily define resources in your REST API. To define a resource simply inherit from the `Resource` class.
