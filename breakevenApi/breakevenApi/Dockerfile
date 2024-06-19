# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

ARG DOTNET_RUNTIME=mcr.microsoft.com/dotnet/aspnet:8.0
ARG DOTNET_SDK=mcr.microsoft.com/dotnet/sdk:8.0

FROM ${DOTNET_RUNTIME} AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM ${DOTNET_SDK} AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["breakevenApi/breakevenApi.csproj", "breakevenApi/"]
RUN dotnet restore "./breakevenApi/breakevenApi.csproj"
COPY . .
WORKDIR "/src/breakevenApi"
RUN dotnet build "./breakevenApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./breakevenApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Run Entity Framework migrations
RUN dotnet tool install --version 5.0 --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
ENTRYPOINT ["dotnet", "ef", "database", "update", "--project", "breakevenApi", "--startup-project", "breakevenApi"]
