using CoreMine.ApplicationBusiness.Common.Pagination;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Stocks.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;

namespace CoreMine.ApplicationBusiness.UseCases.Stocks.Handlers
{
    public class GetStocksQueryHandler : IQueryHandler<GetStockLevelsQuery, PagedResult<StockViewModel>>
    {
        private readonly IReadOnlyStockRepository _repository;

        public GetStocksQueryHandler(IReadOnlyStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<StockViewModel>> HandleAsync(GetStockLevelsQuery query, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            int pageSize = query.PageSize > 0 ? query.PageSize.Value : 10;
            int pageNumber = query.PageNumber > 0 ? query.PageNumber.Value : 1;

            var baseQuery = _repository.GetQueryable()
                .OrderByDescending(p => p.Id)
                .Select(p => new StockViewModel
                {
                    Id = p.Id,
                    LocationId = p.LocationId,
                    LocationName = p.Location.Name,
                    ProductId = p.ProductId,
                    ProductName = p.Product.Name,
                    Quantity = p.Quantity,
                    UpdatedAt = p.UpdatedAt,
                });

            if (query.Id.HasValue)
            {
                baseQuery = baseQuery.Where(p => p.Id == query.Id);
            }

            if (query.Ids.Any())
            {
                baseQuery = baseQuery.Where(p => query.Ids.Contains(p.Id));
            }

            if (query.ProductIds.Any())
            {
                baseQuery = baseQuery.Where(p => query.ProductIds.Contains(p.ProductId));
            }

            if (!string.IsNullOrEmpty(query.ProductName))
            {
                string filter = query.ProductName.ToLower().Trim();
                baseQuery = baseQuery.Where(p => p.ProductName.ToLower().Trim().Contains(filter));
            }

            if (query.LocationId.HasValue)
            {
                baseQuery = baseQuery.Where(p => p.LocationId == query.LocationId);
            }

            if (!string.IsNullOrEmpty(query.LocationName))
            {
                baseQuery = baseQuery.Where(p => p.LocationName.Contains(query.LocationName));
            }

            return await baseQuery.ToPagedResultAsync(pageNumber, pageSize, cancellationToken);
        }
    }
}
