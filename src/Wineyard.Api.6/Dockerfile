#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["Wineyard.Api.6/Wineyard.Api.6.csproj", "Wineyard.Api.6/"]
RUN dotnet restore "Wineyard.Api.6/Wineyard.Api.6.csproj"
COPY . .
WORKDIR "/src/Wineyard.Api.6"
RUN dotnet build "Wineyard.Api.6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Wineyard.Api.6.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Wineyard.Api.6.dll"]
