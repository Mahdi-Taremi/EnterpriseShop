using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shop.Application.Common.Interfaces;
using Shop.Application.Common.Interfaces.Database;
using Shop.Application.Common.Interfaces.Domain;
using Shop.Application.Common.Interfaces.Repositories;
using Shop.Application.Common.Interfaces.Services;
using Shop.Persistence.Context;
using Shop.Persistence.Database;
using Shop.Persistence.Database.Seed;
using Shop.Persistence.Extensions;
using Shop.Persistence.Infrastructure;
using Shop.Persistence.Infrastructure.Domain;
using Shop.Persistence.Repositories;
using Shop.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
        this IServiceCollection services,
         IConfiguration configuration)
        {
            services.AddDbContext<ShopDbContext>((provider, options) =>
            {
                options.UseSqlServer(
                configuration.GetConnectionString("Local"));

                //options.UseLoggerFactory(
                //provider.GetRequiredService<ILoggerFactory>());
             #if DEBUG
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
                //options.LogTo(
                //message => { },
                //LogLevel.Information);
             #endif
            });
            services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ShopDbContext>());

            services.AddScoped<ProductSeeder>();
            services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();

            services.AddScoped(
            typeof(IGenericRepository<>),
            typeof(GenericRepository<>));

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUnitOfWork,UnitOfWork>();

            services.AddScoped<
                IDomainEventDispatcher,
                DomainEventDispatcher>();

            services.AddScoped<IAuditService, AuditService>();

            services.AddScoped<IDomainEventCollector,DomainEventCollector>();

            services.AddDatabaseHealthChecks();

            return services;
        }
    }
}
