using Shop.Application.Common.Interfaces;
using Shop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Infrastructure
{
    public sealed class UnitOfWork:IUnitOfWork
    {
        private readonly ShopDbContext _context;
        public UnitOfWork(
            ShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            return await _context
                .SaveChangesAsync(cancellationToken);
        }
    }
}
