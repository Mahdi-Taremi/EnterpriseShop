using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Interfaces.Domain
{
    public interface IDomainEventCollector
    {
        IReadOnlyCollection<IDomainEvent> Collect(
            IEnumerable<EntityEntry> entries);
    }
}
