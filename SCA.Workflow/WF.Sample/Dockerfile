#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["SCA.Workflow/WF.Sample/WF.Sample.csproj", "SCA.Workflow/WF.Sample/"]
COPY ["SCA.Workflow/WF.Sample.MsSql/WF.Sample.MsSql.csproj", "SCA.Workflow/WF.Sample.MsSql/"]
COPY ["SCA.Workflow/WF.Sample.Business/WF.Sample.Business.csproj", "SCA.Workflow/WF.Sample.Business/"]
RUN dotnet restore "SCA.Workflow/WF.Sample/WF.Sample.csproj"
COPY . .
WORKDIR "/src/SCA.Workflow/WF.Sample"
RUN dotnet build "WF.Sample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WF.Sample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WF.Sample.dll"]