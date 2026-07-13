using MediatR;
using Shop.Application.Common.Interfaces;
using Shop.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CQRS.Products.Commands.CreateProduct
{
    public sealed record CreateProductCommand(
       string Name,
       decimal Price,
       int Stock)
       : ICommand<Result<Guid>>;
}
