using Shop.Domain.Common.Events;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Events.Products
{
    public sealed class ProductUpdatedDomainEvent
        : IDomainEvent
    {
        public Product Product { get; }

        public ProductUpdatedDomainEvent(
            Product product)
        {
            Product = product;
        }
    }
}
