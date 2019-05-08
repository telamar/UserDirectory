FROM microsoft/aspnetcore:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.2 AS build
WORKDIR /src
COPY ["UserDirectory.WebApi/UserDirectory.WebApi.csproj", "UserDirectory.WebApi/"]
RUN dotnet restore "UserDirectory.WebApi/UserDirectory.WebApi.csproj"
COPY . .
WORKDIR "/src/UserDirectory.WebApi"
RUN dotnet build "UserDirectory.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "UserDirectory.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UserDirectory.WebApi.dll"]