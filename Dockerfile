# Build için .NET SDK kullan
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Proje dosyalarını kopyala ve bağımlılıkları yükle
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Çalıştırma için sadece runtime içeren bir image kullan
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# API'nin SQL Server'a bağlanabilmesi için Environment Variable
ENV ConnectionStrings__DefaultConnection="Server=sqlserver,1433;Database=HirovoDB;User=sa;Password=FRAudnxd4rzcVPt;"

# API'yi başlat
ENTRYPOINT ["dotnet", "Hirovo.ApiWithMiddleware.dll"]

