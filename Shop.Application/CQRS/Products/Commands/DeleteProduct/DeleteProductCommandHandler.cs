using MediatR;
using Shop.Application.Common.Errors;
using Shop.Application.Common.Interfaces.Database;
using Shop.Application.Common.Interfaces.Repositories;
using Shop.Application.Common.Results;
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

        private readonly IApplicationDbContext _context;

        public DeleteProductCommandHandler(
            IProductRepository repository,
            IApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
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

            _repository.Delete(product);

            //await _context.SaveChangesAsync(
            //    cancellationToken);

            return Result.Success();
        }
    }
}
