#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

ARG DOTNET_RUNTIME=mcr.microsoft.com/dotnet/aspnet:8.0
ARG DOTNET_SDK=mcr.microsoft.com/dotnet/sdk:8.0

FROM $DOTNET_RUNTIME AS base
USER app
WORKDIR /app
EXPOSE 891
EXPOSE 777

FROM $DOTNET_SDK AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ManageCredits.API/ManageCredits.API.csproj", "ManageCredits.API/"]

COPY ["ManageCredits.API/ManageCredits.API.csproj", "ManageCredits.API/"]
COPY ["ManageCredits.Contracts/ManageCredits.Contracts.csproj", "ManageCredits.Contracts/"]
COPY ["ManageCredits.Domain.Entities/ManageCredits.Domain.Entities.csproj", "ManageCredits.Domain.Entities/"]
COPY ["ManageCredits.Domain.Helpers/ManageCredits.Domain.Helpers.csproj", "ManageCredits.Domain.Helpers/"]
COPY ["ManageCredits.Domain/ManageCredits.Domain.csproj", "ManageCredits.Domain/"]
COPY ["ManageCredits.Infrastructure/ManageCredits.Infrastructure.csproj", "ManageCredits.Infrastructure/"]

COPY ["ManageCredits.Tests/ManageCredits.Tests.csproj", "ManageCredits.Tests/"]

RUN dotnet restore "./ManageCredits.API/ManageCredits.API.csproj"
COPY . .
WORKDIR "/src/ManageCredits.API"
RUN dotnet build "./ManageCredits.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ManageCredits.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ManageCredits.API.dll"]
