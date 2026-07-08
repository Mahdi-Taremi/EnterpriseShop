1 Overview : 
A production-ready ASP.NET Core Web API demonstrating Clean Architecture, CQRS, DDD principles and Enterprise Application Patterns.
This project is designed as a portfolio project to demonstrate software engineering best practices rather than just CRUD implementation.

2 Features : 
- Clean Architecture
- CQRS with MediatR
- Domain Driven Design
- Generic Repository
- Specification Pattern
- Unit of Work
- Domain Events
- FluentValidation
- Pipeline Behaviors
- Result Pattern
- Global Exception Handling
- Soft Delete
- Audit Trail
- Pagination
- SQL Server
- AutoMapper
- Optimistic Concurrency

3 Architecture : 
The project follows Clean Architecture principles.
Presentation
↓
Application
↓
Domain
↓
Persistence

4 Project Structure : 
src/
Shop.Api
Shop.Application
Shop.Domain
Shop.Persistence

5 Technologies : 
- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- MediatR
- FluentValidation
- AutoMapper
- Swagger
- Serilog (Upcoming)
- Redis (Upcoming)

6 Design Patterns

7 Architecture Decisions : 
- Why Clean Architecture?
Business rules should remain independent of infrastructure concerns.
This separation improves maintainability, testability and scalability.

- Why CQRS?
Commands and Queries have different responsibilities.
Separating them improves readability, validation and future scalability.

- Why Repository Pattern?
Repositories isolate persistence concerns from the application layer.
This allows the business logic to remain persistence-agnostic.

- Why Specification Pattern?
Instead of writing LINQ queries everywhere, reusable specifications encapsulate querying logic.

- Why Domain Events?
Entities should notify the outside world when something important happens without directly depending on infrastructure.

- Why Pipeline Behaviors?
Cross-cutting concerns such as validation, logging and transactions should not be duplicated inside handlers.


8 Getting Started

9 API Endpoints

10 Roadmap :
- Authentication (JWT)
- Redis Caching
- Serilog
- Health Checks
- Docker
- API Versioning
- Rate Limiting
- GitHub Actions
- Docker Compose

11 License
