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
     public sealed class ProductUpdatedEventHandler
    : INotificationHandler<ProductUpdatedDomainEvent>
    {
        private readonly ILogger<ProductUpdatedEventHandler> _logger;

        public ProductUpdatedEventHandler(
            ILogger<ProductUpdatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(
            ProductUpdatedDomainEvent notification,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "**** Product Update : {Id} - {Name} ****",
                notification.Product.Id,
                notification.Product.Name);

            return Task.CompletedTask;
        }
    }
}
