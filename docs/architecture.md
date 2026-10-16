# Architecture and boundaries

## Components

| Component | Current responsibility |
| --- | --- |
| `Program.cs` | Registers controllers, SQL Server EF Core context, Swagger, HTTPS redirection, and authorization middleware. |
| `Controllers/AirportController.cs` | Controller-based CRUD endpoints under `api/Airport`. |
| `Data/DataContext.cs` | EF Core context exposing airport records. |
| `Models/Airport.cs` | Minimal airport data model. |
| `Migrations/` | Initial EF Core migration and model snapshot. |
| `Dockerfile` / `docker-compose.yml` | Local image build and SQL Server development stack. |

## Request and data flow

1. A client requests an airport endpoint.
2. `AirportController` reads or modifies records through `DataContext`.
3. EF Core persists to SQL Server using the `DefaultConnection` configuration key.
4. Swagger is exposed only when the application environment is Development.

## Configuration boundary

The compose file contains a deliberately illustrative SQL Server password and is suitable only for a disposable local demo. Treat it as public sample configuration, never as a production secret. A future service must take credentials from a secure environment mechanism, use non-default values, and keep production configuration outside version control.

## Reliability and security gaps

- No automated tests, CI, health endpoint, structured logging, or documented error contract.
- No authentication or authorization policy is configured beyond the middleware call.
- The API model lacks validation and domain-specific constraints.
- .NET 6 is no longer an appropriate starting point for a newly maintained service; any retention should include a supported-runtime plan.
