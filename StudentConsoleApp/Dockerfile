FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StudentConsoleApp/StudentConsoleApp.csproj", "StudentConsoleApp/"]
RUN dotnet restore "StudentConsoleApp/StudentConsoleApp.csproj"
COPY . .
WORKDIR "/src/StudentConsoleApp"
RUN dotnet build "StudentConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentConsoleApp.dll"]
