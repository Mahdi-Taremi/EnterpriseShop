using MediatR;
using Shop.Application.Common.Interfaces;
using Shop.Application.Common.Interfaces.Database;
using Shop.Application.Common.Interfaces.Repositories;
using Shop.Application.Common.Results;
using Shop.Domain.Entities;
using Shop.Domain.Events.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CQRS.Products.Commands.CreateProduct
{
    public sealed class CreateProductCommandHandler
        : IRequestHandler<CreateProductCommand, Result<Guid>>
    {
        private readonly IProductRepository _repository;
        public CreateProductCommandHandler(
            IProductRepository repository
            )
        {
            _repository = repository;
        }

        public async Task<Result<Guid>> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product =
                Product.Create(
                    request.Name,
                    request.Price,
                    request.Stock);
            //var product =
            //  new Product(
            //      request.Name,
            //      request.Price,
            //      request.Stock);

            await _repository.AddAsync(
                product,
                cancellationToken);


            return Result<Guid>.Success(product.Id);
        }
    }
}
