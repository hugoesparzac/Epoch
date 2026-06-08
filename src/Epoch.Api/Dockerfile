FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /workspace

COPY ["Epoch.slnx", "."]
COPY ["src/Epoch.Api/Epoch.Api.csproj", "src/Epoch.Api/"]

# Restaurar paquetes
RUN dotnet restore "src/Epoch.Api/Epoch.Api.csproj"

# Copiar el resto del código fuente
COPY . .
WORKDIR /workspace/src/Epoch.Api

# Compilar
RUN dotnet build "Epoch.Api.csproj" -c $BUILD_CONFIGURATION --no-restore

# Publicar
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Epoch.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false --no-build

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Epoch.Api.dll"]
