FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["wt-lab5-5razor-talko.csproj", "./"]
RUN dotnet restore "wt-lab5-5razor-talko.csproj"

COPY . .
RUN dotnet publish "wt-lab5-5razor-talko.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT:-10000}
EXPOSE 10000

ENTRYPOINT ["dotnet", "wt-lab5-5razor-talko.dll"]