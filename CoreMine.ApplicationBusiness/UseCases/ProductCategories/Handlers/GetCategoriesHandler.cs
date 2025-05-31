using CoreMine.ApplicationBusiness.Common.Pagination;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Categories.Queries;
using CoreMine.Data.ReadModels;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.ApplicationBusiness.UseCases.Categories.Handlers
{
    public class GetCategoriesHandler : IQueryHandler<GetCategoriesQuery, PagedResult<CategoryViewModel>>
    {
        private readonly IReadOnlyCategoriesRepository _categoriesRepository;

        public GetCategoriesHandler(IReadOnlyCategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<PagedResult<CategoryViewModel>> HandleAsync(GetCategoriesQuery query, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            int pageSize = query.PageSize > 0 ? query.PageSize.Value : 10;
            int pageNumber = query.PageNumber > 0 ? query.PageNumber.Value : 1;

            var categoriesQuery = _categoriesRepository.GetQueryable();

            if (query.Id.HasValue)
            {
                categoriesQuery = categoriesQuery.Where(c => c.Id == query.Id.Value);
            }

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                categoriesQuery = categoriesQuery.Where(c => c.Name.Contains(query.Name));
            }

            if (query.ParentId.HasValue)
            {
                categoriesQuery = categoriesQuery.Where(p => p.ParentId == query.ParentId);
            }

            if (query.IsParent.HasValue)
            {
                categoriesQuery = categoriesQuery.Where(p => !p.ParentId.HasValue == query.IsParent.Value);
            }

            return await categoriesQuery.Select(p => new CategoryViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Code = p.Code,
                FullCode = p.FullCategoryCode,
                ParentId = p.ParentId,
            }).ToPagedResultAsync(pageNumber, pageSize, cancellationToken);


        }

    }

}
