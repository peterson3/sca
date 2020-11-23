#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SCA.MVCApp/SCA.MVCApp.csproj", "SCA.MVCApp/"]
RUN dotnet restore "SCA.MVCApp/SCA.MVCApp.csproj"
COPY . .
WORKDIR "/src/SCA.MVCApp"
RUN dotnet build "SCA.MVCApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SCA.MVCApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SCA.MVCApp.dll"]