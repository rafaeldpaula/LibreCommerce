#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/LibreCommerce.WebApi/LibreCommerce.WebApi.csproj", "src/LibreCommerce.WebApi/"]
COPY ["src/LibreCommerce.IoC/LibreCommerce.IoC.csproj", "src/LibreCommerce.IoC/"]
COPY ["src/LibreCommerce.Domain/LibreCommerce.Domain.csproj", "src/LibreCommerce.Domain/"]
COPY ["src/LibreCommerce.Common/LibreCommerce.Common.csproj", "src/LibreCommerce.Common/"]
COPY ["src/LibreCommerce.Application/LibreCommerce.Application.csproj", "src/LibreCommerce.Application/"]
COPY ["src/LibreCommerce.ORM/LibreCommerce.ORM.csproj", "src/LibreCommerce.ORM/"]
RUN dotnet restore "./src/LibreCommerce.WebApi/LibreCommerce.WebApi.csproj"
COPY . .
WORKDIR "/src/src/LibreCommerce.WebApi"
RUN dotnet build "./LibreCommerce.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LibreCommerce.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibreCommerce.WebApi.dll"]