# GeoService

A .NET-based geographical service API with SQL Server database support.

## Prerequisites

- [Docker](https://www.docker.com/get-started)
- [.NET SDK](https://dotnet.microsoft.com/download)
- Entity Framework Core CLI tools

## Getting Started

Run the following commands inside the root folder.

### 1. Install Entity Framework Core Tools

```bash
dotnet tool install --global dotnet-ef
```

### 2. Start SQL Server Database

```bash
docker compose up -d
```

### 3. Update Database Schema

```bash
dotnet ef database update --project .\src\GeoService.Infrastructure --startup-project .\src\GeoService.Api
```

## Database Migration

### 1. Create Migration
```bash
dotnet ef migrations add MigrationName --project .\src\GeoService.Infrastructure --startup-project .\src\GeoService.Api
```

### 2. Update Database Schema

```bash
dotnet ef database update --project .\src\GeoService.Infrastructure --startup-project .\src\GeoService.Api
```

## Project Structure

- **GeoService.Api** - Host
- **GeoService.Application** - Manager
- **GeoService.Infrastructure** - Access
