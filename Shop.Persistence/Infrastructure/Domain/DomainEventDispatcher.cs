using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Application.Common.Interfaces.Domain;
using Shop.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Infrastructure.Domain
{
    public sealed class DomainEventDispatcher
    : IDomainEventDispatcher
    {
        private readonly IPublisher _publisher;

        private readonly ILogger<DomainEventDispatcher> _logger;

        public DomainEventDispatcher(
            IPublisher publisher,
            ILogger<DomainEventDispatcher> logger)
        {
            _publisher = publisher;
            _logger = logger;
        }

        public async Task DispatchAsync(
            IEnumerable<IDomainEvent> domainEvents,
            CancellationToken cancellationToken = default)
        {
            foreach (var domainEvent in domainEvents)
            {
                try
                {
                    await _publisher.Publish(
                        domainEvent,
                        cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        ex,
                        "Error while publishing domain event {DomainEvent}",
                        domainEvent.GetType().Name);
                }
            }
        }
    }
}
