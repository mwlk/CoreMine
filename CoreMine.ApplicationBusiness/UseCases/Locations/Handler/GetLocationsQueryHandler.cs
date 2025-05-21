using CoreMine.ApplicationBusiness.Common.Pagination;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Locations.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace CoreMine.ApplicationBusiness.UseCases.Locations.Handler
{
    public class GetLocationsQueryHandler : IQueryHandler<GetLocationsQuery, PagedResult<LocationViewModel>>
    {
        private readonly IReadOnlyLocationsRepository _repository;

        public GetLocationsQueryHandler(IReadOnlyLocationsRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<LocationViewModel>> HandleAsync(GetLocationsQuery query, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            int pageSize = query.PageSize > 0 ? query.PageSize.Value : 10;
            int pageNumber = query.PageNumber > 0 ? query.PageNumber.Value : 1;

            var baseQuery = _repository.GetQueryable()
                .OrderBy(p => p.Name)
                .AsQueryable();

            if (query.Id.HasValue)
            {
                baseQuery = baseQuery.Where(p => p.Id == query.Id);
            }

            if (query.Ids.Length > 0)
            {
                baseQuery = baseQuery.Where(p => query.Ids.Contains(p.Id));
            }

            if (!query.Name.IsNullOrEmpty())
            {
                baseQuery = baseQuery.Where(p => p.Name.Contains(query.Name));
            }

            if (!query.Description.IsNullOrEmpty())
            {
                baseQuery = baseQuery.Where(p => p.Description.Contains(query.Description));
            }

            return await baseQuery.Select(p => new LocationViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            }).ToPagedResultAsync(pageNumber, pageSize, cancellationToken);
        }
    }
}
