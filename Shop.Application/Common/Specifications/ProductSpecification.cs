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
        {
            Criteria =
                x =>
                //(!filter.CategoryId.HasValue ||
                // x.CategoryId == filter.CategoryId)
                //&&
                //(!filter.BrandId.HasValue ||
                // x.BrandId == filter.BrandId)
                //&&
                (!filter.MinPrice.HasValue ||
                 x.Price >= filter.MinPrice)
                &&
                (!filter.MaxPrice.HasValue ||
                 x.Price <= filter.MaxPrice)
                &&
                (!filter.OnlyAvailable.HasValue ||
                 x.Stock > 0);

            ApplyPaging(
                (filter.PageNumber - 1) *
                filter.PageSize,

                filter.PageSize);

            ApplySorting(filter);
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
