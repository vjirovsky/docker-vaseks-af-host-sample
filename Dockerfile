FROM mcr.microsoft.com/dotnet/sdk:3.1 AS installer-env

COPY src/ /src/
RUN cd /src/SampleFunctionApp && \
    mkdir -p /home/site/wwwroot && \
    dotnet publish *.csproj  -c "Release" --output /home/site/wwwroot

FROM vjirovsky/vaseks-af-host:dotnet-3.1

ENV AzureWebJobsStorage="---YOUR-STORAGE_CONNECTION_STRING---"

COPY --from=installer-env ["/home/site/wwwroot", "/home/site/wwwroot"]

# if you want to have health check
# WARNING - this healthcheck is exposed (anybody can call this healthcheck)
HEALTHCHECK --interval=1m --timeout=3s CMD curl -f http://localhost:80/api/healthcheck || exit 1
