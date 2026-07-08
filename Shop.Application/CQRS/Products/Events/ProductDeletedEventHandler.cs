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
    public sealed class ProductDeletedEventHandler
    : INotificationHandler<ProductDeletedDomainEvent>
    {
        private readonly ILogger<ProductDeletedEventHandler> _logger;

        public ProductDeletedEventHandler(
            ILogger<ProductDeletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(
            ProductDeletedDomainEvent notification,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "**** Product Delete : {Id} - {Name} ****",
                notification.Product.Id,
                notification.Product.Name);

            return Task.CompletedTask;
        }
    }
}
