using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PagedResponse<T>>
            ToPagedListAsync<T>(
                this IQueryable<T> query,
                PagedRequest request,
                CancellationToken cancellationToken = default)
        {
            var totalCount =
                await query.CountAsync(cancellationToken);

            var items =
                await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(cancellationToken);

            return new PagedResponse<T>
            {
                Items = items,

                PageNumber = request.PageNumber,

                PageSize = request.PageSize,

                TotalCount = totalCount,

            };
        }
    }
}
