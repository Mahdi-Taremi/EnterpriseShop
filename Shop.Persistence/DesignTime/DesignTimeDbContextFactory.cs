using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Shop.Persistence.Context;
using Shop.Persistence.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.DesignTime
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShopDbContext>
    {
        public ShopDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder =
                new DbContextOptionsBuilder<ShopDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=.;Database=ShopDB;User Id=MahdiTaremi;Password=12;TrustServerCertificate=True;");

            // When use Migration -> Beacuse Non-existence ServiceProvider
            return new ShopDbContext(
             optionsBuilder.Options,
             new NullDateTimeProvider(),
             new NullCurrentUserService(),
             new NullDomainEventDispatcher());
        }
    }
}
