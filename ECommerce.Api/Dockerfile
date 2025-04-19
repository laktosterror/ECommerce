FROM mcr.microsoft.com/dotnet/sdk:8.0.408 AS build
WORKDIR /source
COPY . .
RUN dotnet restore --runtime linux-x64
RUN dotnet publish ECommerce.Api -c release -o /app  \
    --runtime linux-x64  \
    --no-restore \
    --self-contained true \
    /p:PublishTrimmed=true \
    /p:PublishSingleFile=true

FROM alpine:3.21
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["./ECommerce.Api"]