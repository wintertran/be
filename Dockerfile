# Stage 1: Build ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Sao chép file solution và csproj từ thư mục gốc
COPY be.sln .            # Sao chép be.sln từ thư mục gốc
COPY *.csproj ./         # Sao chép be.csproj từ thư mục gốc

# Khôi phục các dependencies
RUN dotnet restore *.csproj

# Sao chép toàn bộ source code
COPY . .

# Build ứng dụng
RUN dotnet build *.csproj -c Release -o /app

# Stage 2: Publish ứng dụng
FROM build AS publish
RUN dotnet publish *.csproj -c Release -o /publish

# Stage 3: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Sao chép output từ bước publish
COPY --from=publish /publish .

# Chạy ứng dụng
ENTRYPOINT ["dotnet", "be.dll"]
