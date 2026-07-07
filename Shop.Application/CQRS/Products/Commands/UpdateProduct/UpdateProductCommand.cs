using MediatR;
using Shop.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CQRS.Products.Commands.UpdateProduct
{
    public sealed record UpdateProductCommand(
     Guid Id,
     string Name,
     decimal Price,
     int Stock
     //,byte[] RowVersion
        )
     : IRequest<Result>;
}
