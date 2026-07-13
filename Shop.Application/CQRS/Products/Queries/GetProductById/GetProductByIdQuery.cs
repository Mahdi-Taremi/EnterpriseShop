using MediatR;
using Shop.Application.CQRS.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CQRS.Products.Queries.GetProductById
{
    public sealed record GetProductByIdQuery(
      Guid Id)
      : IRequest<ProductDto>;
}
