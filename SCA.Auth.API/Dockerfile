#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SCA.Auth.API/SCA.Auth.API.csproj", "SCA.Auth.API/"]
RUN dotnet restore "SCA.Auth.API/SCA.Auth.API.csproj"
COPY . .
WORKDIR "/src/SCA.Auth.API"
RUN dotnet build "SCA.Auth.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SCA.Auth.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SCA.Auth.API.dll"]