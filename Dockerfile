FROM microsoft/dotnet:2.1-sdk AS installer-env

COPY src/ /src/
RUN cd /src/SampleFunctionApp && \
    mkdir -p /home/site/wwwroot && \
    dotnet publish *.csproj  -c "Release" --output /home/site/wwwroot

FROM vjirovsky/vaseks-af-host:dotnet-2.0

ENV AzureWebJobsStorage="---YOUR-STORAGE_CONNECTION_STRING---"

COPY --from=installer-env ["/home/site/wwwroot", "/home/site/wwwroot"]
