# Installation

You can either choose to use our template to scaffold a new project, or you can install the library and migrate your current structure to ServiceBlock.

## Quick start

The dotnet CLI comes with build in scaffolding tools. We provide a package containing useful templates for creating ServiceBlocks.

To install all templates, run:

```
dotnet new -i ServiceBlock.Templates
```

### Create a ServiceBlock service

```
mkdir <YOUR_PROJECT_NAME> && cd <YOUR_PROJECT_NAME>
dotnet new serviceblock
```

## Migrate existing project

Migrate from ASP.NET:

```
dotnet add package ServiceBlock
```

Then go to your Program.cs and call `ServiceBlock.Startup.Block.Run(args)` from your main function.

Create a new project called `<YOUR_PROJECT_NAME>.Interface`. This project will contain the public interface of your service. Now you can start defining resources.
