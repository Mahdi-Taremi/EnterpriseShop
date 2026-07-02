using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Specifications
{
    public class AvailableProductsSpecification
     : BaseSpecification<Product>
    {
        public AvailableProductsSpecification()
            : base(x => x.Stock > 0)
        {
            ApplyOrderBy(x => x.Name);
        }
    }
}
