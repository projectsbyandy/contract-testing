FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Producer.EmulsiveFactory/Producer.EmulsiveFactory.csproj", "Producer.EmulsiveFactory/"]
RUN dotnet restore "Producer.EmulsiveFactory/Producer.EmulsiveFactory.csproj"
COPY . .
WORKDIR "/src/Producer.EmulsiveFactory"
RUN dotnet build "Producer.EmulsiveFactory.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Producer.EmulsiveFactory.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Producer.EmulsiveFactory.dll"]
