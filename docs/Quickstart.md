# Quick start

The dotnet CLI comes with build in scaffolding tools. We provide a package containing useful templates for creating ServiceBlocks.

To install all templates, run:

```bash
dotnet new -i ServiceBlock.Templates
```

## Create a ServiceBlock service

The easiest way to get started is to use the basic serviceblock template.
Run the following commands to create the necessary files for a simple serviceblock project.

```bash
mkdir <YOUR_PROJECT_NAME> && cd <YOUR_PROJECT_NAME>
dotnet new serviceblock
```

Now you can start defining [resources](./guides/resources.md) in your Interface project.

## Migrate existing project

To migrate an existing project you need to adhere to the ServiceBlock project structure.
You must, at least, have 2 projects in your application, one which is the asp.net entry project, and the other which is a classlib.

The classlib will contain the public interface of your service, and it's name should be suffixed with `.Interface`.

Navigate to your asp.et project, add the ServiceBlock package, and add a reference to your interface project.

```bash
cd <YOUR_PROJECT_NAME>
dotnet add package ServiceBlock
dotnet add reference ../<YOUR_PROJECT_NAME>.Interface
```

Now navigate to your interface project and add the necessary ServiceBlock packages.

```bash
cd <YOUR_PROJECT_NAME>.Interface
dotnet add package ServiceBlock.Interface
dotnet add package ServiceBlock.Storage
```

Then go to your Program.cs and call `ServiceBlock.Core.Block.Run(args)` from your main function.

You can now start declaring ServiceBlock resources in your interface.
