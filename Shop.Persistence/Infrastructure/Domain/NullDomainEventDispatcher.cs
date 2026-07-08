using Shop.Application.Common.Interfaces.Domain;
using Shop.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Infrastructure.Domain
{
    public sealed class NullDomainEventDispatcher
        : IDomainEventDispatcher
    {
        public Task DispatchAsync(
            IEnumerable<IDomainEvent> domainEvents,
            CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
