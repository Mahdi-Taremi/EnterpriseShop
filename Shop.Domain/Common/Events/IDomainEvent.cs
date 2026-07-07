using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Common.Events
{
    public interface IDomainEvent : INotification
    {
    }
}
