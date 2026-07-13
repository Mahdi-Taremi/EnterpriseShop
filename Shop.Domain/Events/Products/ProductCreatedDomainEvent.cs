using Shop.Domain.Common.Events;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Events.Products
{
    public sealed class ProductCreatedDomainEvent
    : IDomainEvent
    {
        public Product Product { get; }

        public ProductCreatedDomainEvent(Product product)
        {
            Product = product;
        }
    }
}
