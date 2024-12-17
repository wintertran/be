# S? d?ng .NET SDK ?? build ?ng d?ng
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Sao chép file csproj và khôi ph?c các dependency
COPY *.sln .
COPY be/*.csproj ./be/
RUN dotnet restore ./be/be.csproj

# Sao chép t?t c? các file source và build
COPY . .
WORKDIR /src/be
RUN dotnet publish -c Release -o /app

# S? d?ng .NET Runtime ?? ch?y ?ng d?ng
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

# C?ng mà ?ng d?ng l?ng nghe
EXPOSE 80

# Ch?y ?ng d?ng
ENTRYPOINT ["dotnet", "be.dll"]
