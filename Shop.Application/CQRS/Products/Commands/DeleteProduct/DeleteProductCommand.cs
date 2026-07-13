using MediatR;
using Shop.Application.Common.Interfaces;
using Shop.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CQRS.Products.Commands.DeleteProduct
{
    public sealed record DeleteProductCommand(Guid Id): ICommand<Result>;
}
