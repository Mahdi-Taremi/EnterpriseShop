using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Specifications
{
    public class LowStockSpecification
      : BaseSpecification<Product>
    {
        public LowStockSpecification(int threshold)
            : base(x => x.Stock <= threshold)
        {
        }
    }
}
