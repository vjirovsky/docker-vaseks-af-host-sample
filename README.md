# Sample dotnet Vasek's Azure Functions project

This repo contains Docker image with sample project for [Vasek's Azure Functions runtime host](https://github.com/vjirovsky/docker-vaseks-af-host/). 

```docker
FROM microsoft/dotnet:2.1-sdk AS installer-env

COPY src/ /src/
RUN cd /src/SampleFunctionApp && \
    mkdir -p /home/site/wwwroot && \
    dotnet publish *.csproj -c "Release" --output /home/site/wwwroot

FROM vjirovsky/vaseks-af-host:dotnet-2.0

ENV AzureWebJobsStorage="---YOUR-STORAGE_CONNECTION_STRING---"

COPY --from=installer-env ["/home/site/wwwroot", "/home/site/wwwroot"]

WORKDIR /home/site/wwwroot

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000/tcp
```


From Dockerfile you are able to pass on some parameters to your Function application by ENV command (see <i>AzureWebJobsStorage</i> parameter).

### Result
<img src="https://user-images.githubusercontent.com/2659294/49704046-e3b71100-fc0d-11e8-9c27-c738485f7308.png">
