#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["track-it/track-it.csproj", "track-it/"]
RUN dotnet restore "track-it/track-it.csproj"
COPY . .
WORKDIR "/src/track-it"
RUN dotnet build "track-it.csproj" -c Release -o /app/build

FROM build AS publish
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash - && apt-get install -yq nodejs
RUN dotnet publish "track-it.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN curl -sL https://deb.nodesource.com/setup_14.x | bash - && apt-get install -yq nodejs
ENTRYPOINT ["dotnet", "track-it.dll"]