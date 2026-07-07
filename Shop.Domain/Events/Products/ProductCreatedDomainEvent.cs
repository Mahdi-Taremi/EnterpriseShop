using Shop.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Events.Products
{
    public sealed record ProductCreatedDomainEvent(Guid ProductId,string Name): IDomainEvent;
}
