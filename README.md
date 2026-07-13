1 Overview : 
# 🛒 Enterprise Shop API : Production-ready ASP.NET Core Web API built with Clean Architecture, CQRS, Domain-Driven Design and modern engineering practices.
Enterprise Shop is a production-oriented ASP.NET Core Web API demonstrating modern backend architecture and engineering practices. The project is built around Clean Architecture, CQRS, Domain-Driven Design (DDD), MediatR, Repository Pattern, Specification Pattern, Domain Events, and Pipeline Behaviors with a strong focus on maintainability, scalability, and testability.

![.NET](https://img.shields.io/badge/.NET-8-blue)

![CQRS](https://img.shields.io/badge/CQRS-MediatR-success)

![Architecture](https://img.shields.io/badge/Clean%20Architecture-DDD-blueviolet)

![License](https://img.shields.io/badge/license-MIT-green)

![Status](https://img.shields.io/badge/status-active-success)

This project intentionally demonstrates multiple architectural patterns and practices for learning and showcasing software design skills. In real-world systems, architecture should be chosen based on business complexity rather than applying every pattern by default.

2 Features : 
| Feature                   | Status |
| ------------------------- | ------ |
| Clean Architecture        | ✅      |
| CQRS                      | ✅      |
| MediatR                   | ✅      |
| Repository Pattern        | ✅      |
| Specification Pattern     | ✅      |
| Unit Of Work              | ✅      |
| Domain Events             | ✅      |
| Soft Delete               | ✅      |
| Validation Pipeline       | ✅      |
| Logging Pipeline          | ✅      |
| Performance Pipeline      | ✅      |
| Transaction Pipeline      | ✅      |
| Global Exception Handling | ✅      |
| Pagination                | ✅      |
| AutoMapper                | ✅      |
| Swagger                   | ✅      |
| Redis                     | 🚧     |
| JWT Authentication        | 🚧     |
| Docker                    | 🚧     |


3 Architecture : 
Why This Architecture?
EnterpriseShop is primarily a learning and portfolio project designed to demonstrate architectural concepts and software engineering practices rather than represent a one-size-fits-all solution.

The goal of this project is to explore and implement patterns such as Clean Architecture, Domain-Driven Design (DDD), CQRS, Domain Events, Repository Pattern, Specification Pattern and Pipeline Behaviors in a single codebase.

In real-world software, architecture should always be driven by business requirements, system complexity and team size. Not every application requires all of these patterns, and simplicity is often the better choice for smaller systems.

The architectural decisions in this project were intentionally made to practice, compare and better understand enterprise application design.

Detailed architecture documentation is available in /architecture.md.

4 Project Structure : 
src/
ShopAPI
Shop.Application
Shop.Domain
Shop.Persistence

5 Technologies : 
| Category      | Technology               |
| ------------- | ------------------------ |
| Framework     | ASP.NET Core 8           |
| Language      | C#                       |
| ORM           | EF Core                  |
| Database      | SQL Server               |
| CQRS          | MediatR                  |
| Validation    | FluentValidation         |
| Mapping       | AutoMapper               |
| Logging       | Microsoft ILogger        |
| Documentation | Swagger                  |
| Architecture  | Clean Architecture + DDD |
- Serilog (Upcoming)
- Redis (Upcoming)

6 Running :
1) git clone ...
2) dotnet restore
3) dotnet ef database update
4) dotnet run

7 Architecture Decisions : 
ADR (Architecture Decision Records)
- ADR- Clean Architecture
- ADR- Domain Events
- ADR- Soft Delete

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
- Why Persistence ?
Persistence is separated into Assembly because of its ability to develop independently, separate responsibilities, and reduce dependency on other infrastructure.

8 Roadmap :
- Authentication (JWT)
- Redis Caching
- Serilog
- Health Checks
- Docker
- API Versioning
- Rate Limiting
- Docker Compose

10 License

## Author
Mahdi Taremi
