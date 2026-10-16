# Current-state documentation

## Purpose

This repository is a learning implementation of a small ASP.NET Core API for managing airport records. It demonstrates controller-based CRUD, Entity Framework Core migrations, SQL Server integration, Swagger, and a Docker Compose development setup.

## Current state

- Target: ASP.NET Core on .NET 6 with Entity Framework Core 7 packages.
- Domain: a minimal `Airport` record with name, type, city, timezone, coordinates, and website fields.
- Persistence: SQL Server through `DataContext` and committed EF Core migration artifacts.
- Delivery: Dockerfile and Docker Compose definitions are present.
- Tests and CI: none were found.
- Additional routes: `HomeController` contains unrelated C# language-learning examples; they are not airport-management functionality.

## Decision

Keep as a reference for early .NET Web API and EF Core work, but exclude it from the primary portfolio showcase pending an owner decision. It needs a focused product boundary, supported runtime, tests, security configuration, and delivery automation before being presented as a maintained service.

See the [charter](project-charter.md), [architecture](architecture.md), and [delivery handoff](delivery-and-quality.md).
