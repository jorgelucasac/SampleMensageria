#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/services/Estudos.Viagem.WebApi/Estudos.Viagem.WebApi.csproj", "src/services/Estudos.Viagem.WebApi/"]
COPY ["src/building blocks/Estudos.Viagem.Core/Estudos.Viagem.Core.csproj", "src/building blocks/Estudos.Viagem.Core/"]
COPY ["src/services/Estudos.Viagem.Infrastructure.RabbitMq/Estudos.Viagem.Infrastructure.RabbitMq.csproj", "src/services/Estudos.Viagem.Infrastructure.RabbitMq/"]
COPY ["src/services/Estudos.Viagem.Application/Estudos.Viagem.Application.csproj", "src/services/Estudos.Viagem.Application/"]
COPY ["src/building blocks/Estudos.Viagem.Messages/Estudos.Viagem.Messages.csproj", "src/building blocks/Estudos.Viagem.Messages/"]
COPY ["src/services/Estudos.Viagem.Infrastructure.SqlServer/Estudos.Viagem.Infrastructure.SqlServer.csproj", "src/services/Estudos.Viagem.Infrastructure.SqlServer/"]
RUN dotnet restore "src/services/Estudos.Viagem.WebApi/Estudos.Viagem.WebApi.csproj"
COPY . .
WORKDIR "/src/src/services/Estudos.Viagem.WebApi"
RUN dotnet build "Estudos.Viagem.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Estudos.Viagem.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Estudos.Viagem.WebApi.dll"]