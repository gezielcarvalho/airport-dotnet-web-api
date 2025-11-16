# Airport Management API

A .NET 6.0 Web API for managing airport data with Entity Framework Core and SQL Server.

## Features

- RESTful API endpoints for airport management
- Entity Framework Core with SQL Server
- Swagger/OpenAPI documentation
- Docker and Docker Compose support
- Database migrations

## Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) (for local development)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) (for containerized deployment)

## Getting Started

### Running with Docker (Recommended)

1. Clone the repository:

   ```bash
   git clone https://github.com/gezielcarvalho/airport-dotnet-web-api.git
   cd airport-dotnet-web-api
   ```

2. Build and start the containers:

   ```bash
   docker-compose up --build
   ```

3. Apply database migrations:

   ```bash
   docker-compose exec web dotnet ef database update
   ```

4. Access the API:
   - Swagger UI: http://localhost:5000/swagger
   - API: http://localhost:5000

### Running Locally

1. Update the connection string in `appsettings.json` to point to your local SQL Server instance.

2. Restore dependencies:

   ```bash
   dotnet restore
   ```

3. Apply migrations:

   ```bash
   dotnet ef database update
   ```

4. Run the application:

   ```bash
   dotnet run
   ```

5. Access the API:
   - Swagger UI: https://localhost:7013/swagger
   - API: https://localhost:7013

## Docker Configuration

The application includes:

- **Dockerfile**: Multi-stage build optimized for .NET 6.0
- **docker-compose.yml**: Orchestrates the web API and SQL Server
- **.dockerignore**: Excludes unnecessary files from Docker builds

### Docker Commands

```bash
# Start services
docker-compose up -d

# Stop services
docker-compose down

# View logs
docker-compose logs -f web

# Rebuild containers
docker-compose up --build

# Remove volumes (WARNING: deletes database data)
docker-compose down -v
```

## API Endpoints

The API provides endpoints for managing airports. Access the Swagger UI for detailed API documentation and testing.

## Database Migrations

### Create a new migration:

```bash
dotnet ef migrations add MigrationName
```

### Apply migrations:

```bash
# Local
dotnet ef database update

# Docker
docker-compose exec web dotnet ef database update
```

## Project Structure

```
├── Controllers/          # API controllers
├── Data/                # Database context
├── Migrations/          # EF Core migrations
├── Models/              # Data models
├── Properties/          # Launch settings
├── Dockerfile           # Docker configuration
├── docker-compose.yml   # Docker Compose configuration
└── Program.cs           # Application entry point
```

## Technologies

- .NET 6.0
- ASP.NET Core Web API
- Entity Framework Core 7.0
- SQL Server
- Swagger/OpenAPI
- Docker

## References

1. https://www.youtube.com/watch?v=Fbf_ua2t6v4
