using Microsoft.EntityFrameworkCore;
using Shop.Persistence.Context;
using Shop.Persistence.Database.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Database
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ShopDbContext _context;
        private readonly ProductSeeder _productSeeder;

        public DatabaseInitializer(
            ShopDbContext context,
            ProductSeeder productSeeder)
        {
            _context = context;
            _productSeeder = productSeeder;
        }

        public async Task InitializeAsync(
            CancellationToken cancellationToken = default)
        {
            await _context.Database.MigrateAsync(cancellationToken);

            await _productSeeder.SeedAsync(cancellationToken);
        }
    }
}
