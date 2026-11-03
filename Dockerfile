FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ENV LANG ru_RU.UTF-8
ENV LC_ALL ru_RU.UTF-8
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
ENV LANG ru_RU.UTF-8
ENV LC_ALL ru_RU.UTF-8
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 10000
ENTRYPOINT ["dotnet", "wt-lab5-5razor-talko.dll"]