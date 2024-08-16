#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FoodManagement_UI/FoodManagement_UI.csproj", "FoodManagement_UI/"]
RUN dotnet restore "FoodManagement_UI/FoodManagement_UI.csproj"
COPY . .
WORKDIR "/src/FoodManagement_UI"
RUN dotnet build "FoodManagement_UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FoodManagement_UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FoodManagement_UI.dll"]