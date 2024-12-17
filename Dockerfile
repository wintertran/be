# Chọn image base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Thư mục làm việc trong container
WORKDIR /src

# Sao chép solution file
COPY *.sln .  

# Sao chép file csproj từ thư mục be
COPY be/*.csproj ./be/

# Khôi phục dependency
RUN dotnet restore ./be/be.csproj

# Sao chép toàn bộ source code
COPY . .

# Build ứng dụng
RUN dotnet build ./be/be.csproj -c Release -o /app

# Publish ứng dụng
RUN dotnet publish ./be/be.csproj -c Release -o /app

# Image runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

# Chạy ứng dụng
ENTRYPOINT ["dotnet", "be.dll"]
