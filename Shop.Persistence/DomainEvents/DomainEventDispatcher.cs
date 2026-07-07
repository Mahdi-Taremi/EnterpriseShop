using MediatR;
using Shop.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.DomainEvents
{
    public sealed class DomainEventDispatcher
     : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;

        public DomainEventDispatcher(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task DispatchAsync(
            IEnumerable<IDomainEvent> events,
            CancellationToken cancellationToken = default)
        {
            foreach (var domainEvent in events)
            {
                await _mediator.Publish(
                    domainEvent,
                    cancellationToken);
            }
        }
    }
}
