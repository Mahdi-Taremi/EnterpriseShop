using MediatR;
using static System.Net.Mime.MediaTypeNames;
//using Shop.Application.Common.Interfaces;
using Shop.Application.Common.Interfaces.Repositories;
using Shop.Application.Common.Models.Products;
using Shop.Application.Common.Specifications;
using Shop.Application.CQRS.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CQRS.Products.Queries.GetProducts
{
    public sealed class GetProductsQueryHandler: IRequestHandler< GetProductsQuery,IReadOnlyList<ProductDto>>
    {
        private readonly IProductRepository _repository;

        public GetProductsQueryHandler(
            IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<ProductDto>>
            Handle(
                GetProductsQuery request,
                CancellationToken cancellationToken)
        {
            var specification =
                new ProductSpecification(
                    new ProductFilter());

            var products =
                await _repository.ListAsync(
                    specification,
                    cancellationToken);

            return products
                .Select(x => new ProductDto
                {
                    Id = x.Id,

                    Name = x.Name,

                    Price = x.Price,

                    Stock = x.Stock
                })
                .ToList();
        }
    }
}
