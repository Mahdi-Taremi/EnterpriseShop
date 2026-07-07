using Shop.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
    private readonly List<IDomainEvent> _domainEvents = [];

        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public byte[] RowVersion { get; protected set; } = default!;

        protected BaseEntity()
        {
              Id = Guid.NewGuid();
            //Use .NET 9
            //Id = Guid.CreateVersion7();
        }
        public IReadOnlyCollection<IDomainEvent> DomainEvents
            => _domainEvents.AsReadOnly();

        public void AddDomainEvent(
          IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        public void RemoveDomainEvent(
          IDomainEvent domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
