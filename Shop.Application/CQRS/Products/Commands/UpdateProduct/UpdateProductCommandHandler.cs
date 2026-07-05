using MediatR;
using Shop.Application.Common.Interfaces.Database;
using Shop.Application.Common.Interfaces.Repositories;
using Shop.Application.Common.Results;
using Shop.Application.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CQRS.Products.Commands.UpdateProduct
{
    public sealed class UpdateProductCommandHandler
    : IRequestHandler<UpdateProductCommand, Result>
    {
        private readonly IProductRepository _repository;

        private readonly IApplicationDbContext _context;

        public UpdateProductCommandHandler(
            IProductRepository repository,
            IApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<Result> Handle(
            UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product =
                await _repository.GetByIdAsync(
                    request.Id,
                    cancellationToken);

            if (product is null)
                return Result.Failure(
                    ProductErrors.NotFound);

            product.Update(
                request.Name,
                request.Price,
                request.Stock);

            _repository.Update(product);

            //await _context.SaveChangesAsync(
            //    cancellationToken);

            return Result.Success();
        }
    }
}
