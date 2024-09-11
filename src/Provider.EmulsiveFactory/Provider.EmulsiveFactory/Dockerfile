FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Provider.EmulsiveFactory/Provider.EmulsiveFactory.csproj", "Provider.EmulsiveFactory/"]
RUN dotnet restore "Provider.EmulsiveFactory/Provider.EmulsiveFactory.csproj"
COPY . .
WORKDIR "/src/Provider.EmulsiveFactory"
RUN dotnet build "Provider.EmulsiveFactory.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Provider.EmulsiveFactory.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Provider.EmulsiveFactory.dll"]
