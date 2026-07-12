# Decision

Why Domain Events?
Use Domain Events with MediatR.
Each Aggregate Root publishes events.
Handlers react independently.

Problem :
Business operations should not directly trigger side effects.

Consequences :
+ Loose Coupling
+ Open Closed Principle
+ Multiple Handlers
+ Future Event Bus support

Trade-offs :
Harder debugging.
Eventually Consistent mindset.