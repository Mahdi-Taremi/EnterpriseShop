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
    public class ProductRepository
    : GenericRepository<Product>,
      IProductRepository
    {
        public ProductRepository(
            ShopDbContext context)
            : base(context)
        {
        }

        public async Task<List<Product>> GetAvailableProductsAsync(
            CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(x => x.Stock > 0)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Product>> GetLowStockProductsAsync(
            int threshold,
            CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(x => x.Stock <= threshold)
                .ToListAsync(cancellationToken);
        }

        //public async Task<List<Product>> GetProductsByCategoryAsync(
        //    int categoryId,
        //    CancellationToken cancellationToken = default)
        //{
        //    return await DbSet
        //        .Where(x => x.CategoryId == categoryId)
        //        .ToListAsync(cancellationToken);
        //}
    }
}
