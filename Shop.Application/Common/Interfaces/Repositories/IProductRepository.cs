using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Interfaces.Repositories
{
    public interface IProductRepository
      : IGenericRepository<Product>
    {
        Task<List<Product>> GetAvailableProductsAsync(
            CancellationToken cancellationToken = default);

        Task<List<Product>> GetLowStockProductsAsync(
            int threshold,
            CancellationToken cancellationToken = default);

        //Task<List<Product>> GetProductsByCategoryAsync(
        //    int categoryId,
        //    CancellationToken cancellationToken = default);
    }
}
