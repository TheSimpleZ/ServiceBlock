FROM mcr.microsoft.com/dotnet/core/aspnet:3.0

COPY SampleService/bin/Release/netcoreapp3.0/publish/ app/

ENTRYPOINT ["dotnet", "app/SampleService.dll"]