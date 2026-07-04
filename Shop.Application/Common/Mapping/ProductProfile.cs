using AutoMapper;
using Shop.Application.CQRS.Products.Commands.CreateProduct;
using Shop.Application.CQRS.Products.Commands.UpdateProduct;
using Shop.Application.CQRS.Products.DTOs;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shop.Application.Common.Mapping
{
    public sealed class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<CreateProductCommand, Product>();

            CreateMap<UpdateProductCommand, Product>();
        }
    }
}
