# Decision
ADR (Architecture Decision Records) :
This project intentionally demonstrates multiple architectural patterns and practices for learning and showcasing software design skills.
In real-world systems, architecture should be chosen based on business complexity rather than applying every pattern by default.

Why Clean Architecture?
Need separation between business logic and infrastructure.

Problem : 
Business logic was tightly coupled to infrastructure,
making testing and maintenance difficult.

Consequences :
+ Easier testing
+ Independent business rules
+ Better scalability
+ Infrastructure can be replaced

Trade-offs :
More folders.
More abstractions.