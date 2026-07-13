    using MediatR;
using Shop.Application.Common.Errors;
using Shop.Application.Common.Interfaces.Database;
using Shop.Application.Common.Interfaces.Repositories;
using Shop.Application.Common.Results;
using Shop.Domain.Events.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CQRS.Products.Commands.DeleteProduct
{
    public sealed class DeleteProductCommandHandler
    : IRequestHandler<DeleteProductCommand, Result>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(
            IProductRepository repository
            )
        {
            _repository = repository;
        }

        public async Task<Result> Handle(
            DeleteProductCommand request,
            CancellationToken cancellationToken)
        {
            var product =
                await _repository.GetByIdAsync(
                    request.Id,
                    cancellationToken);

            if (product is null)
                return Result.Failure(
                    ProductErrors.NotFound);

            product.Delete();
            _repository.Delete(product);


            return Result.Success();
        }
    }
}
