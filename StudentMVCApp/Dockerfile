FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StudentMVCAppNew/StudentMVCAppNew.csproj", "StudentMVCAppNew/"]
RUN dotnet restore "StudentMVCAppNew/StudentMVCAppNew.csproj"
COPY . .
WORKDIR "/src/StudentMVCAppNew"
RUN dotnet build "StudentMVCAppNew.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentMVCAppNew.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentMVCAppNew.dll"]
