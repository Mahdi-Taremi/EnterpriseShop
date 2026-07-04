using AutoMapper;
using MediatR;
//using Shop.Application.Common.Interfaces;
using Shop.Application.Common.Interfaces.Repositories;
using Shop.Application.Common.Models.Pagination;
using Shop.Application.Common.Models.Products;
using Shop.Application.Common.Specifications;
using Shop.Application.CQRS.Products.DTOs;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shop.Application.CQRS.Products.Queries.GetProducts
{
    public sealed class GetProductsQueryHandler
      : IRequestHandler<
          GetProductsQuery,
          PagedResponse<ProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(
            IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<ProductDto>> Handle(
     GetProductsQuery request,
     CancellationToken cancellationToken)
        {
            var filter = new ProductFilter
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            var specification =
                new ProductSpecification(filter);

            var totalCount =
                await _repository.CountAsync(
                    specification,
                    cancellationToken);

            var products =
                await _repository.ListAsync(
                    specification,
                    cancellationToken);

            //var items =
            //    products.Select(x => new ProductDto
            //    {
            //        Id = x.Id,
            //        Name = x.Name,
            //        Price = x.Price,
            //        Stock = x.Stock
            //    }).ToList();
            var items =
                _mapper.Map<List<ProductDto>>(products);
            return new PagedResponse<ProductDto>
            {
                Items = items,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalCount
            };
        }
    }
}