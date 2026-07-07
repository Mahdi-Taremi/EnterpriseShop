using Shop.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.DomainEvents
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync(
            IEnumerable<IDomainEvent> events,
            CancellationToken cancellationToken = default);
    }
}
