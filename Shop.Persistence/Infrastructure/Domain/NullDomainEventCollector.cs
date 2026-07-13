using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Application.Common.Interfaces.Domain;
using Shop.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Infrastructure.Domain
{
    public sealed class NullDomainEventCollector
        : IDomainEventCollector
    {
        public IReadOnlyCollection<IDomainEvent> Collect(
            IEnumerable<EntityEntry> entries)
        {
            return Array.Empty<IDomainEvent>();
        }
    }
}
