using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Interfaces.Database;
using Shop.Domain.Entities;
using Shop.Persistence.Context;
using Shop.Persistence.Database.Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Database.Seed
{
    public class ProductSeeder
    {
        private readonly IApplicationDbContext _context;

        public ProductSeeder(ShopDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            if (await _context.Products
                   .IgnoreQueryFilters()
                   .AnyAsync(cancellationToken))
            {
                return;
            }

            var products = new ProductFaker().Generate(500);

            await _context.Products.AddRangeAsync(products, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}