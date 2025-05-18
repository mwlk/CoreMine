using CoreMine.ApplicationBusiness.Common.Pagination;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.ProductStateTypes.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.ApplicationBusiness.UseCases.ProductStateTypes.Handler
{
    public class GetProductStateTypesHandler : IQueryHandler<GetProductStateTypeQuery, PagedResult<ProductStateTypeViewModel>>
    {
        private readonly IReadOnlyProductStateTypesRepository _repository;

        public GetProductStateTypesHandler(IReadOnlyProductStateTypesRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<ProductStateTypeViewModel>> HandleAsync(GetProductStateTypeQuery query, CancellationToken cancellationToken)
        {
            int pageSize = query.PageSize > 0 ? query.PageSize.Value : 10;
            int pageNumber = query.PageNumber > 0 ? query.PageNumber.Value : 1;

            var baseQuery = _repository.GetQueryable()
                .OrderBy(p => p.Name)
                .Select(p => new ProductStateTypeViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return await baseQuery.ToPagedResultAsync(pageNumber, pageSize, cancellationToken);
        }

    }
}
