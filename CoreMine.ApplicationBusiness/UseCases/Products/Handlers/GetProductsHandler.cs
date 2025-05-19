using CoreMine.ApplicationBusiness.Common.Pagination;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Products.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;

namespace CoreMine.ApplicationBusiness.UseCases.Products.Handlers
{
    public class GetProductsHandler : IQueryHandler<GetProductsQuery, PagedResult<ProductViewModel>>
    {
        private readonly IReadOnlyProductsRepository _repository;

        public GetProductsHandler(IReadOnlyProductsRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<ProductViewModel>> HandleAsync(GetProductsQuery query, CancellationToken cancellationToken)
        {
            int pageSize = query.PageSize > 0 ? query.PageSize.Value : 10;
            int pageNumber = query.PageNumber > 0 ? query.PageNumber.Value : 1;

            var baseQuery = _repository.GetQueryable()
                .OrderBy(p => p.Name)
                .AsQueryable();

            if (query.Id.HasValue)
            {
                baseQuery = baseQuery.Where(p => p.Id == query.Id);
            }

            if (query.CategoryIds.Length != 0)
            {
                baseQuery = baseQuery.Where(p => query.CategoryIds.Contains(p.CategoryId));
            }

            var mapped = baseQuery.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                CategoryName = p.Category.Name ?? "-"
            });

            return await mapped.ToPagedResultAsync(pageNumber, pageSize, cancellationToken);
        }
    }
}
