FROM mcr.microsoft.com/dotnet/sdk:6.0.100-alpine3.14-amd64 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:6.0.100-alpine3.14-amd64 AS build
WORKDIR /src
COPY "./backend.fsproj" .
RUN dotnet restore "./backend.fsproj"
COPY . .
WORKDIR /src/.
RUN dotnet build "backend.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "backend.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "backend.dll" ]