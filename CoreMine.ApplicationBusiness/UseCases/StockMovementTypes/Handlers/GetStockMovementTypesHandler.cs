using CoreMine.ApplicationBusiness.Common.Pagination;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.StockMovementTypes.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;

namespace CoreMine.ApplicationBusiness.UseCases.StockMovementTypes.Handlers
{
    public class GetStockMovementTypesHandler : IQueryHandler<GetStockMovementTypesQuery, PagedResult<StockMovementTypeViewModel>>
    {
        private readonly IReadOnlyStockMovementTypesRepository _repository;

        public GetStockMovementTypesHandler(IReadOnlyStockMovementTypesRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<StockMovementTypeViewModel>> HandleAsync(GetStockMovementTypesQuery query, CancellationToken cancellationToken)
        {
            int pageSize = query.PageSize > 0 ? query.PageSize.Value : 10;
            int pageNumber = query.PageNumber > 0 ? query.PageNumber.Value : 1;

            var baseQuery = _repository.GetQuaryable()
                .OrderBy(p => p.Name)
                .Select(p => new StockMovementTypeViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    IsPositive = p.IsPositive
                });

            if (query.Id.HasValue)
            {
                baseQuery = baseQuery.Where(p => p.Id == query.Id);
            }

            if (query.Ids.Length != 0)
            {
                baseQuery = baseQuery.Where(p => query.Ids.Contains(p.Id));
            }

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                var nameFilter = query.Name.ToLower();
                baseQuery = baseQuery.Where(p => p.Name.ToLower().Contains(nameFilter));
            }


            if (query.IsPositive.HasValue)
            {
                baseQuery = baseQuery.Where(p => p.IsPositive == query.IsPositive.Value);
            }

            return await baseQuery.ToPagedResultAsync(pageNumber, pageSize, cancellationToken);
        }
    }
}
