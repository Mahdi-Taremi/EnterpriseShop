using Shop.Application.Common.Specifications;
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
    }
}
