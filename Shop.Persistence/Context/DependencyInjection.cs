using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Common.Interfaces.Repositories;
using Shop.Application.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Database.Seed;
using Shop.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Context
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
        this IServiceCollection services,
         IConfiguration configuration)
        {
            services.AddDbContext<ShopDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("Local"));
            });
            services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ShopDbContext>());

            services.AddScoped<ProductSeeder>();
            services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();

            services.AddScoped(
            typeof(IGenericRepository<>),
            typeof(GenericRepository<>));

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
