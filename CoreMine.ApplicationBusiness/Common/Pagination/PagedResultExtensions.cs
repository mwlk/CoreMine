using CoreMine.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.ApplicationBusiness.Common.Pagination
{
    public static class PagedResultExtensions
    {
        public static async Task<PagedResult<T>> ToPagedResultAsync<T>(
            this IQueryable<T> query,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            if (pageNumber <= 0) pageNumber = 1;

            if (pageSize <= 0)
            {
                var allItems = await query.ToListAsync(cancellationToken);
                return new PagedResult<T>
                {
                    TotalCount = allItems.Count,
                    PageNumber = 1,
                    PageSize = allItems.Count,
                    Items = allItems
                };
            }

            var total = await query.CountAsync(cancellationToken);
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<T>
            {
                TotalCount = total,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Items = items
            };
        }
    }
}
