# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copie o arquivo do projeto para o contêiner
COPY ["vstudy.smartgarbage/vstudy.smartgarbage.csproj", "vstudy.smartgarbage/"]

# Restaure as dependências do projeto
RUN dotnet restore "vstudy.smartgarbage/vstudy.smartgarbage.csproj"

# Copie todos os outros arquivos do projeto
COPY . .

# Compile o projeto
RUN dotnet build "vstudy.smartgarbage/vstudy.smartgarbage.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release

# Publique o projeto
RUN dotnet publish "vstudy.smartgarbage/vstudy.smartgarbage.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

# Copie os arquivos publicados do estágio de publicação
COPY --from=publish /app/publish .

# Defina o comando de entrada
ENTRYPOINT ["dotnet", "vstudy.smartgarbage.dll"]