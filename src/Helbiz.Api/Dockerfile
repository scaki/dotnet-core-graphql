FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Helbiz.Api/Helbiz.Api.csproj", "Helbiz.Api/"]
RUN dotnet restore "src/Helbiz.Api/Helbiz.Api.csproj"
COPY . .
WORKDIR "/src/Helbiz.Api"
RUN dotnet build "Helbiz.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Helbiz.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Helbiz.Api.dll"]
