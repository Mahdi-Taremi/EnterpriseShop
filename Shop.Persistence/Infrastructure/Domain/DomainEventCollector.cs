using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Application.Common.Interfaces.Domain;
using Shop.Domain.Common.Events;
using Shop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Infrastructure.Domain
{
    public sealed class DomainEventCollector
        : IDomainEventCollector
    {
        public IReadOnlyCollection<IDomainEvent> Collect(
            IEnumerable<EntityEntry> entries)
        {
            var entities = entries
                .Where(e => e.Entity is BaseEntity)
                .Select(e => (BaseEntity)e.Entity)
                .ToList();

            var events = entities
                .SelectMany(e => e.DomainEvents)
                .ToList();

            foreach (var entity in entities)
            {
                entity.ClearDomainEvents();
            }

            return events;
        }
    }
}
