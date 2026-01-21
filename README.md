- docker
dotnet tool install --global dotnet-ef
docker compose up -d
dotnet ef migrations add Initial --project .\src\GeoService.Infrastructure --startup-project .\src\GeoService.Api 
dotnet ef database update --project .\src\GeoService.Infrastructure --startup-project .\src\GeoService.Api