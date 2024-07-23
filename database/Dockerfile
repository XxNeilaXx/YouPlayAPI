#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["database/Migrations.csproj", "database/"]
RUN dotnet restore "./database/Migrations.csproj"
COPY . .
WORKDIR "/src/database"
RUN dotnet build "./Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["database/Scripts", "./Scripts/"]
ENTRYPOINT ["dotnet", "Migrations.dll"]


#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#WORKDIR /app
#COPY . ./
#RUN dotnet restore
#RUN dotnet publish Migrations.csproj -c Release -o out --no-restore

#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
#WORKDIR /app
#COPY --from=build /app/out .
#ENTRYPOINT ["dotnet", "Migrations.dll"]

# docker build -t database-migrations .
# docker run -p 5000:80 database-migrations <connectionString>