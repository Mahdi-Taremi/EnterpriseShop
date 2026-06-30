using Shop.Application.Common.Specifications;
using Shop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity>
     where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);
        Task<TEntity?> FirstOrDefaultAsync(
            BaseSpecification<TEntity> specification,
            CancellationToken cancellationToken = default);
        Task<TEntity?> SingleOrDefaultAsync(
            BaseSpecification<TEntity> specification,
            CancellationToken cancellationToken = default);
        Task<IReadOnlyList<TEntity>> ListAsync(
            BaseSpecification<TEntity> specification,
            CancellationToken cancellationToken = default);
        // Count > 0
        Task<bool> AnyAsync(
            BaseSpecification<TEntity> specification,
            CancellationToken cancellationToken = default);
        //Pagination، Dashboard, Reports
        Task<int> CountAsync(
            BaseSpecification<TEntity> specification,
            CancellationToken cancellationToken = default);
        Task AddAsync(
            TEntity entity,
            CancellationToken cancellationToken = default);
        // Seed, Import , Bulk Insert
        Task AddRangeAsync(
            IEnumerable<TEntity> entities,
            CancellationToken cancellationToken = default);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
