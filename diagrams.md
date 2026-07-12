Diagram 1 – Solution Overview

                +----------------------+
                |      Shop.API        |
                | Controllers          |
                | Middleware           |
                +----------+-----------+
                           │
                           ▼
                +----------------------+
                |   Shop.Application   |
                | CQRS                 |
                | MediatR              |
                | Behaviors            |
                | Specifications       |
                | Validation           |
                +----------+-----------+
                           │
                           ▼
                +----------------------+
                |    Shop.Domain       |
                | Entities             |
                | Aggregate Roots      |
                | Domain Events        |
                +----------▲-----------+
                           │
                +----------+-----------+
                |  Shop.Persistence    |
                | DbContext            |
                | Repositories         |
                | Unit Of Work         |
                | Specifications       |
                +----------+-----------+
                           │
                           ▼
                     SQL Server

Diagram 2 – Request Flow
HTTP Request
      │
      ▼
Controller
      │
      ▼
IMediator.Send()
      │
      ▼
ValidationBehavior
      │
      ▼
LoggingBehavior
      │
      ▼
PerformanceBehavior
      │
      ▼
TransactionBehavior
      │
      ▼
Command / Query Handler
      │
      ▼
Repository
      │
      ▼
Specification
      │
      ▼
DbContext
      │
      ▼
SQL Server


Diagram 3 – Command Flow

CreateProductCommand
        │
        ▼
CreateProductHandler
        │
        ▼
Product.Create(...)
        │
        ▼
AddDomainEvent(...)
        │
        ▼
Repository.AddAsync(...)
        │
        ▼
UnitOfWork.SaveChangesAsync()
        │
        ▼
Domain Event Dispatcher
        │
        ▼
ProductCreatedEventHandler

