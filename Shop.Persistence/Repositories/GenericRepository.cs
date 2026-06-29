using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Interfaces.Repositories;
using Shop.Application.Common.Specifications;
using Shop.Domain.Entities.Base;
using Shop.Persistence.Context;
using Shop.Persistence.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Repositories
{
    public class GenericRepository<TEntity>
    : IGenericRepository<TEntity>
    where TEntity : BaseEntity
    {
        protected readonly ShopDbContext Context;

        protected readonly DbSet<TEntity> DbSet;

        public GenericRepository(
            ShopDbContext context)
        {
            Context = context;

            DbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            return await DbSet.FindAsync(
                new object[] { id },
                cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return await DbSet.ToListAsync(
                cancellationToken);
        }

        public virtual async Task AddAsync(TEntity entity,
            CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(
                entity,
                cancellationToken);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
        public async Task<List<TEntity>>
            GetAllAsync(
            BaseSpecification<TEntity> specification,
            CancellationToken cancellationToken)
        {
            var query =
                SpecificationEvaluator<TEntity>
                .GetQuery(
                    DbSet.AsQueryable(),
                    specification);

            return await query
                .ToListAsync(cancellationToken);
        }
    }
}
