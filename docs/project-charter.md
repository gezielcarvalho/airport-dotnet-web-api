# Project charter

## Learning objective

Practice creating a REST API and a containerized local dependency stack using ASP.NET Core, Entity Framework Core, SQL Server, and Swagger.

## Scope represented today

- Read, create, update, and delete operations for airport records.
- SQL Server persistence and a first EF Core migration.
- Swagger configuration for the Development environment.
- Local Docker Compose orchestration.

## Not in scope

- Airport operations, flight scheduling, safety, regulatory, or real-world aviation workflows.
- Authentication, authorization, auditing, rate limits, tenancy, or service-level reliability.
- Production secrets, deployment, monitoring, backup, or incident response.
- The unrelated language examples exposed through `HomeController`.

## Ownership and decision gate

The repository remains part of the personal learning archive. An owner must choose whether to archive it or fund an explicitly scoped rewrite. Do not present it as operational airport software.

## Modernization acceptance criteria

1. Upgrade to a supported .NET runtime and align package versions.
2. Separate or remove learning-only endpoints.
3. Define the airport domain and API contract, including validation and error behavior.
4. Externalize configuration and use secret injection instead of checked-in sample values for non-local use.
5. Add automated tests, CI, health checks, authentication/authorization where needed, and deployment evidence.
