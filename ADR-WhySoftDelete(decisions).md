# Decision

Why Soft Delete?
Deleting records permanently causes data loss.

Decision :
Entities are marked as deleted.
Global Query Filter hides deleted entities.

Consequences :
+ Recovery
+ Audit
+ History
+ Compliance

Trade-offs :
Database grows over time.
Queries become slightly more complex.