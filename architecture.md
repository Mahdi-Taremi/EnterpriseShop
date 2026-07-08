# Project Architecture

```text
                     Client
                        │
                        ▼
               ASP.NET Core API
                        │
                        ▼
                  MediatR Pipeline
                        │
        ┌───────────────┼────────────────┐
        │               │                │
        ▼               ▼                ▼
 Validation      Logging Behavior   Performance
        │               │                │
        └───────────────┼────────────────┘
                        │
                        ▼
                Command / Query
                        │
                        ▼
                 Handler (CQRS)
                        │
                        ▼
                Repository Layer
                        │
                        ▼
                EF Core + DbContext
                        │
                        ▼
                   SQL Server
```

# Clean Architecture

```text
                +---------------------+
                |        API          |
                | Controllers         |
                +----------+----------+
                           │
                           ▼
                +---------------------+
                |    Application      |
                | CQRS                |
                | MediatR             |
                | Behaviors           |
                | Validation          |
                +----------+----------+
                           │
                           ▼
                +---------------------+
                |      Domain         |
                | Entities            |
                | Value Objects       |
                | Domain Events       |
                +----------+----------+
                           ▲
                           │
                +----------+----------+
                |    Persistence      |
                | EF Core             |
                | Repositories        |
                | SQL Server          |
                +---------------------+
```

API
 │
 ▼
Application
 │
 ▼
Domain

Persistence
 │
 ▼
Domain

Persistence
 │
 ▼
Application

---> This : 

API

↓

Application

↓

Domain

↑

Persistence