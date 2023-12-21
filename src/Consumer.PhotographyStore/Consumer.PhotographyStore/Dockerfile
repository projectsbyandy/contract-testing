FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Consumer.PhotographyStore/Consumer.PhotographyStore.csproj", "Consumer.PhotographyStore/"]
RUN dotnet restore "Consumer.PhotographyStore/Consumer.PhotographyStore.csproj"
COPY . .
WORKDIR "/src/Consumer.PhotographyStore"
RUN dotnet build "Consumer.PhotographyStore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Consumer.PhotographyStore.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Consumer.PhotographyStore.dll"]
