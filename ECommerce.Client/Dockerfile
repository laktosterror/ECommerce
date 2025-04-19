FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore ECommerce/ECommerce.Client --runtime linux-x64
RUN ls
RUN dotnet publish ECommerce/ECommerce.Client -c release -o /app  \
    --runtime linux-x64  \
    --no-restore \
    --self-contained true \
    /p:PublishTrimmed=true \
    /p:PublishSingleFile=true

FROM mcr.microsoft.com/dotnet/runtime-deps:8.0-noble-chiseled
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["./ECommerce.Client"]