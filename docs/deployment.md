# Deployment

The application is meant to be run as a docker container. To build the container, simply run:

```text
dotnet build -c Release
docker build -t some-tag .
docker run --rm -it -p 8080:80 some-tag
```

Now open your web browser an navigate to `http://localhost:8080`.

