#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["back_end/PostsMicroservice/PostsMicroservice/PostsMicroservice.csproj", "back_end/PostsMicroservice/PostsMicroservice/"]
RUN dotnet restore "back_end/PostsMicroservice/PostsMicroservice/PostsMicroservice.csproj"
COPY . .
WORKDIR "/src/back_end/PostsMicroservice/PostsMicroservice"
RUN dotnet build "PostsMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PostsMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PostsMicroservice.dll"]
