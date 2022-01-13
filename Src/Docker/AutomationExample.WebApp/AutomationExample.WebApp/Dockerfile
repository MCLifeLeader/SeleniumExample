#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AutomationExample.WebApp/AutomationExample.WebApp.csproj", "AutomationExample.WebApp/"]
RUN dotnet restore "AutomationExample.WebApp/AutomationExample.WebApp.csproj"
COPY . .
WORKDIR "/src/AutomationExample.WebApp"
RUN dotnet build "AutomationExample.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AutomationExample.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutomationExample.WebApp.dll"]