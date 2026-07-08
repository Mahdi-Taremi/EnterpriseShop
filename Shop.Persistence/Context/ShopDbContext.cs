using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Interfaces.Database;
using Shop.Application.Common.Interfaces.Domain;
using Shop.Application.Common.Interfaces.Services;
using Shop.Application.Common.Results;
using Shop.Domain.Common.Events;
using Shop.Domain.Entities;
using Shop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Context
{
    public class ShopDbContext : DbContext, IApplicationDbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;
        private readonly IAuditService _auditService;

        public ShopDbContext(DbContextOptions<ShopDbContext> options, IDomainEventDispatcher dispatcher, 
            IAuditService auditService) : base(options)
        {
            _dispatcher = dispatcher;
            _auditService = auditService;
        }

        // ReView 
        protected override void OnModelCreating(
         ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add future - Reflection  (Global Query Filter)
            modelBuilder.Entity<Product>()
            .HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ShopDbContext).Assembly);
        }

        // SaveChangesAsync --> SaveChangesInterceptor (Interceptor)
        public override async Task<int> SaveChangesAsync(
       CancellationToken cancellationToken = default)
        {
            _auditService.ApplyAuditInformation(ChangeTracker.Entries());

            var domainEvents = ChangeTracker
                .Entries<BaseEntity>()
                .Select(x => x.Entity)
                .SelectMany(x => x.DomainEvents)
                .ToList();


            foreach (var entity in ChangeTracker
                .Entries<BaseEntity>()
                .Select(x => x.Entity))
            {
                entity.ClearDomainEvents();
            }

            var result =
              await base.SaveChangesAsync(cancellationToken);

            await _dispatcher.DispatchAsync(
                domainEvents,
                cancellationToken);

            return result;
        }
        public DbSet<Product> Products => Set<Product>();
    }
}