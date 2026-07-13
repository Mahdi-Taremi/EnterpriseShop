using Shop.Application.CQRS.Products.DTOs;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CQRS.Products.Mapping
{
    public static class ProductMappings
    {
        public static ProductDto ToDto(
            this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    }
}
