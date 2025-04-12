FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Ecommerce.WebApi/Ecommerce.WebApi.csproj", "src/Ecommerce.WebApi/"]
COPY ["src/Ecommerce.IoC/Ecommerce.IoC.csproj", "src/Ecommerce.IoC/"]
COPY ["src/Ecommerce.Domain/Ecommerce.Domain.csproj", "src/Ecommerce.Domain/"]
COPY ["src/Ecommerce.Common/Ecommerce.Common.csproj", "src/Ecommerce.Common/"]
COPY ["src/Ecommerce.Application/Ecommerce.Application.csproj", "src/Ecommerce.Application/"]
COPY ["src/Ecommerce.ORM/Ecommerce.ORM.csproj", "src/Ecommerce.ORM/"]
RUN dotnet restore "./src/Ecommerce.WebApi/Ecommerce.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Ecommerce.WebApi"
RUN dotnet build "./Ecommerce.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ecommerce.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce.WebApi.dll"]