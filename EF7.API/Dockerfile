
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EF7.API/EF7.API.csproj", "EF7.API/"]
RUN dotnet restore "EF7.API/EF7.API.csproj"
COPY . .
WORKDIR "/src/EF7.API"
RUN dotnet build "EF7.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EF7.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EF7.API.dll"]