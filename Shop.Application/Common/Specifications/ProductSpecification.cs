using Shop.Application.Common.Models.Products;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Specifications
{
    public class ProductSpecification
      : BaseSpecification<Product>
    {
        public ProductSpecification(ProductFilter filter)
    : base(x =>
        string.IsNullOrWhiteSpace(filter.Search)
        || x.Name.Contains(filter.Search))
        {
            ApplySorting(filter);

            ApplyPaging(
                (filter.PageNumber - 1) * filter.PageSize,
                filter.PageSize);
        }

        private void ApplySorting(ProductFilter filter)
        {
            switch (filter.SortBy?.ToLower())
            {
                case "price":
                    if (filter.Descending)
                        ApplyOrderByDescending(x => x.Price);
                    else
                        ApplyOrderBy(x => x.Price);
                    break;

                case "name":
                    if (filter.Descending)
                        ApplyOrderByDescending(x => x.Name);
                    else
                        ApplyOrderBy(x => x.Name);
                    break;

                default:
                    ApplyOrderBy(x => x.Id);
                    break;
            }
        }
    }
}
