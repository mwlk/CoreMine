using CoreMine.ApplicationBusiness.Common.Pagination;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Suppliers.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace CoreMine.ApplicationBusiness.UseCases.Suppliers.Handlers
{
    public class GetSuppliersQueryHandler : IQueryHandler<GetSuppliersQuery, PagedResult<SupplierViewModel>>
    {
        private readonly IReadOnlySuppliersRepository _repository;

        public GetSuppliersQueryHandler(IReadOnlySuppliersRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<SupplierViewModel>> HandleAsync(GetSuppliersQuery query, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            int pageSize = query.PageSize > 0 ? query.PageSize.Value : 10;
            int pageNumber = query.PageNumber > 0 ? query.PageNumber.Value : 1;

            var baseQuery = _repository.GetQueryable()
                .OrderByDescending(p => p.Surname)
                .AsQueryable();

            if (query.Id.HasValue)
            {
                baseQuery = baseQuery.Where(p => p.Id == query.Id.Value);
            }

            if (query.Ids.Length > 0)
            {
                baseQuery = baseQuery.Where(p => query.Ids.Contains(p.Id));
            }

            if (!query.FullName.IsNullOrEmpty())
            {
                baseQuery = baseQuery.Where(p => string.Concat(p.Name, ' ', p.Surname).Contains(query.FullName));
            }

            return await baseQuery.Select(p => new SupplierViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Surname = p.Surname,
                Phone = p.Phone,
                Contact = p.Contact,
                CreatedAt = p.CreatedAt
            }).ToPagedResultAsync(pageNumber, pageSize, cancellationToken);
        }
    }
}
