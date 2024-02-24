#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Acme.Store.DbMigrator/Acme.Store.DbMigrator.csproj", "src/Acme.Store.DbMigrator/"]
COPY ["src/Acme.Store.Application.Contracts/Acme.Store.Application.Contracts.csproj", "src/Acme.Store.Application.Contracts/"]
COPY ["src/Acme.Store.Domain.Shared/Acme.Store.Domain.Shared.csproj", "src/Acme.Store.Domain.Shared/"]
COPY ["src/Acme.Store.EntityFrameworkCore/Acme.Store.EntityFrameworkCore.csproj", "src/Acme.Store.EntityFrameworkCore/"]
COPY ["src/Acme.Store.Domain/Acme.Store.Domain.csproj", "src/Acme.Store.Domain/"]
RUN dotnet restore "./src/Acme.Store.DbMigrator/Acme.Store.DbMigrator.csproj"
COPY . .
WORKDIR "/src/src/Acme.Store.DbMigrator"
RUN dotnet build "./Acme.Store.DbMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Acme.Store.DbMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Acme.Store.DbMigrator.dll"]