# Dockerfile (örnek)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore ./Hirovo.sln
RUN dotnet publish ./BaseModules/IAM/BaseModules.IAM.Api/BaseModules.IAM.Api.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app

# 🔥 appsettings.json'u ekliyoruz
COPY ./BaseModules/IAM/BaseModules.IAM.Api/appsettings.json ./BaseModules/IAM/BaseModules.IAM.Api/appsettings.json

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "BaseModules.IAM.Api.dll"]
