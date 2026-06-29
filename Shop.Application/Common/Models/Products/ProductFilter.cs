using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Models.Products
{
    public class ProductFilter
    {
        public int? CategoryId { get; init; }
        public int? BrandId { get; init; }
        public decimal? MinPrice { get; init; }
        public decimal? MaxPrice { get; init; }
        public bool? OnlyAvailable { get; init; }
        public string? SortBy { get; init; }
        public bool Descending { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 20;
    }
}
