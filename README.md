# Sample dotnet Vasek's Azure Functions project

This repo contains Docker image with sample project for [Vasek's Azure Functions runtime host](https://github.com/vjirovsky/docker-vaseks-af-host/). 

```docker
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS installer-env

COPY src/ /src/
RUN cd /src/SampleFunctionApp && \
    mkdir -p /home/site/wwwroot && \
    dotnet publish *.csproj -c "Release" --output /home/site/wwwroot

FROM vjirovsky/vaseks-af-host:dotnet-3.1

ENV AzureWebJobsStorage="---YOUR-STORAGE_CONNECTION_STRING---"

COPY --from=installer-env ["/home/site/wwwroot", "/home/site/wwwroot"]

# if you want to have health check
# WARNING - this healthcheck is exposed (anybody can call this healthcheck)
HEALTHCHECK --interval=5m --timeout=3s CMD curl -f http://localhost:80/api/healthcheck || exit 1
```


From Dockerfile you are able to pass on some parameters to your Function application by ENV command (see <i>AzureWebJobsStorage</i> parameter).

### Result
<img src="https://user-images.githubusercontent.com/2659294/49704046-e3b71100-fc0d-11e8-9c27-c738485f7308.png">
