using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Models.Pagination
{
    public class PagedRequest
    {
        private const int MaxPageSize = 100;
        public int PageNumber { get; init; } = 1;
        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            init => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public string? Search { get; init; }
        public string? SortBy { get; init; }
        public bool Descending { get; init; }
    }
    //public class PagedRequest
    //{
    //    private const int MaxPageSize = 100;
    //    private int _pageSize = 10;

    //    public int PageNumber { get; set; } = 1;

    //    public int PageSize
    //    {
    //        get => _pageSize;
    //        set
    //        {
    //            _pageSize = value > MaxPageSize
    //                ? MaxPageSize
    //                : value;
    //        }
    //    }
    //}
}
