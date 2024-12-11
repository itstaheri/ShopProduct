
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release


RUN ls
WORKDIR /src
COPY ["Shop.Endpoint.Rest/Shop.Endpoint.Rest.csproj", "Shop.Endpoint.Rest/"]
COPY ["Common/Common.csproj", "Common/"]
COPY ["Shop.Application/Shop.Application.csproj", "Shop.Application/"] 
COPY ["Shop.Domain/Shop.Domain.csproj", "Shop.Domain/"]
COPY ["Shop.Domain.Contract/Shop.Domain.Contract.csproj", "Shop.Domain.Contract/"]
COPY ["Shop.Infrastructure/Shop.Infrastructure.csproj", "Shop.Infrastructure/"]

RUN dotnet restore "./Shop.Endpoint.Rest/./Shop.Endpoint.Rest.csproj"
COPY . .
WORKDIR "/src/Shop.Endpoint.Rest"
RUN dotnet build "./Shop.Endpoint.Rest.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Shop.Endpoint.Rest.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shop.Endpoint.Rest.dll"]