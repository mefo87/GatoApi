FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Api/GatoApi.csproj", "Api/"]
COPY ["Business/Business.csproj", "Business/"]
COPY ["Data/Data.csproj", "Data/"]
RUN dotnet restore "Api/GatoApi.csproj"

COPY . .
WORKDIR "/src/Api"

RUN dotnet build "GatoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GatoApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "GatoApi.dll"] 