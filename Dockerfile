# S? d?ng .NET SDK ?? build ?ng d?ng
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Sao ch�p file csproj v� kh�i ph?c c�c dependency
COPY *.sln .
COPY be/*.csproj ./be/
RUN dotnet restore ./be/be.csproj

# Sao ch�p t?t c? c�c file source v� build
COPY . .
WORKDIR /src/be
RUN dotnet publish -c Release -o /app

# S? d?ng .NET Runtime ?? ch?y ?ng d?ng
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

# C?ng m� ?ng d?ng l?ng nghe
EXPOSE 80

# Ch?y ?ng d?ng
ENTRYPOINT ["dotnet", "be.dll"]
