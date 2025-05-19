using CoreMine.ApplicationBusiness.Common.Pagination;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.UnitOfMeasures.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;

namespace CoreMine.ApplicationBusiness.UseCases.UnitOfMeasures.Handlers
{
    public class GetUnitOfMeasuresHandler : IQueryHandler<GetUnitOfMeasuresQuery, PagedResult<UnitOfMeasureViewModel>>
    {
        private readonly IReadOnlyUnitOfMeasuresRepository _repository;

        public GetUnitOfMeasuresHandler(IReadOnlyUnitOfMeasuresRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<UnitOfMeasureViewModel>> HandleAsync(GetUnitOfMeasuresQuery query, CancellationToken cancellationToken)
        {
            int pageSize = query.PageSize > 0 ? query.PageSize.Value: 10;
            int pageNumber = query.PageNumber > 0 ? query.PageNumber.Value : 1;

            var baseQuery = _repository.GetQueryable()
                .OrderBy(p => p.Name)
                .Select(p => new UnitOfMeasureViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Symbol = p.Symbol
                });

            return await baseQuery.ToPagedResultAsync(pageNumber, pageSize, cancellationToken);
        }
    }
}
