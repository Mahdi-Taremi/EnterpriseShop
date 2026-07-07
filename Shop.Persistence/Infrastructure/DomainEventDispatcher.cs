using MediatR;
using Shop.Application.Common.Interfaces.Domain;
using Shop.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Infrastructure
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
            IEnumerable<IDomainEvent> domainEvents,
            CancellationToken cancellationToken = default)
        {
            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(
                    domainEvent,
                    cancellationToken);
            }
        }
    }
}
