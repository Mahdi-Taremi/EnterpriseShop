using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Interfaces.Repositories;
using Shop.Domain.Entities;
using Shop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Repositories
{
    public sealed class ProductRepository
    : GenericRepository<Product>,
      IProductRepository
    {
        public ProductRepository(
            ShopDbContext context)
            : base(context)
        {
        }
    }
}
