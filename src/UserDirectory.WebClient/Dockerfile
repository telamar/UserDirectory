FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["UserDirectory.WebClient/UserDirectory.WebClient.csproj", "UserDirectory.WebClient/"]
RUN dotnet restore "UserDirectory.WebClient/UserDirectory.WebClient.csproj"
COPY . .
WORKDIR "/src/UserDirectory.WebClient"
RUN dotnet build "UserDirectory.WebClient.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "UserDirectory.WebClient.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UserDirectory.WebClient.dll"]