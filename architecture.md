This project intentionally demonstrates multiple architectural patterns and practices for learning and showcasing software design skills. In real-world systems, architecture should be chosen based on business complexity rather than applying every pattern by default. 

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


                  Client
                     │
                     ▼
              ASP.NET Core API
                     │
                     ▼
                MediatR Pipeline
                     │
     ┌───────────────┼────────────────┐
     ▼               ▼                ▼

 Validation      Logging        Performance
  Behavior        Behavior        Behavior

                     │
                     ▼
              Command / Query
                     │
                     ▼
                  Handler
                     │
      ┌──────────────┼──────────────┐
      ▼                             ▼

 Repository                Specification

      │

      ▼

 Aggregate Root

      │

      ▼

 Domain Events

      │

      ▼

 Unit Of Work

      │

      ▼

 EF Core DbContext

      │

      ▼

 SQL Server
