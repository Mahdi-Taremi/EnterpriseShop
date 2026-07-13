using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Domain.Events.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CQRS.Products.Events
{
    public sealed class ProductCreatedEventHandler
    : INotificationHandler<ProductCreatedDomainEvent>
    {
        private readonly ILogger<ProductCreatedEventHandler> _logger;

        public ProductCreatedEventHandler(
            ILogger<ProductCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(
            ProductCreatedDomainEvent notification,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "**** Product Created : {Id} - {Name} ****",
                notification.Product.Id,
                notification.Product.Name);

            return Task.CompletedTask;
        }
    }
}
