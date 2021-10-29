#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["track-it/track-it.csproj", "track-it/"]
RUN dotnet restore "track-it/track-it.csproj"
COPY . .
WORKDIR "/src/track-it"
RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash - && apt-get install -yq nodejs build-essential
RUN npm install -g npm
RUN dotnet build "track-it.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "track-it.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "track-it.dll"]
