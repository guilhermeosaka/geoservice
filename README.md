# GeoService

A .NET-based geographical service API with PostgreSQL database support.

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

### 2. Start PostgreSQL Database

```bash
docker compose up -d
```

### 3. Create Migration

```bash
dotnet ef migrations add MigrationName --project .\src\GeoService.Infrastructure --startup-project .\src\GeoService.Api
```

### 4. Update Database Schema

```bash
dotnet ef database update --project .\src\GeoService.Infrastructure --startup-project .\src\GeoService.Api
```

## Project Structure

- **GeoService.Api** - Host
- **GeoService.Application** - Manager
- **GeoService.Infrastructure** - Access
