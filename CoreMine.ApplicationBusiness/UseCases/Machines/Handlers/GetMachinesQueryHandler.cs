using CoreMine.ApplicationBusiness.Common.Pagination;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Machines.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace CoreMine.ApplicationBusiness.UseCases.Machines.Handlers
{
    public class GetMachinesQueryHandler : IQueryHandler<GetMachinesQuery, PagedResult<MachineViewModel>>
    {
        private readonly IReadOnlyMachinesRepository _repository;

        public GetMachinesQueryHandler(IReadOnlyMachinesRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<MachineViewModel>> HandleAsync(GetMachinesQuery query, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            int pageSize = query.PageSize > 0 ? query.PageSize.Value : 10;
            int pageNumber = query.PageNumber > 0 ? query.PageNumber.Value : 1;

            var baseQuery = _repository.GetQueryable()
                .OrderByDescending(p => p.AcquisitionDate)
                .AsQueryable();

            if (query.Id.HasValue)
            {
                baseQuery = baseQuery.Where(p => p.Id == query.Id.Value);
            }

            if (query.Ids.Length > 0)
            {
                baseQuery = baseQuery.Where(p => query.Ids.Contains(p.Id));
            }

            if (!string.IsNullOrEmpty(query.Code))
            {
                baseQuery = baseQuery.Where(p => p.Code.Contains(query.Code));
            }

            if (query.IsActive.HasValue)
            {
                baseQuery = baseQuery.Where(p => p.IsActive == query.IsActive.Value);
            }

            return await baseQuery.Select(p => new MachineViewModel
            {
                Id = p.Id,
                Code = p.Code,
                AdquisitionDate = p.AcquisitionDate,
                Description = p.Description,
                IsActive = p.IsActive,
                ModelYear = p.ModelYear
            }).ToPagedResultAsync(pageNumber, pageSize, cancellationToken);

        }
    }
}
