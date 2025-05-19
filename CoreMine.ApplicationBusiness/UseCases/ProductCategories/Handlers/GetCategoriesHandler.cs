using Azure.Core;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Categories.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.ApplicationBusiness.UseCases.Categories.Handlers
{
    public class GetCategoriesHandler: IQueryHandler<GetCategoriesQuery, PagedResult<CategoryViewModel>>
    {
        private readonly IReadOnlyCategoriesRepository _categoriesRepository;

        public GetCategoriesHandler(IReadOnlyCategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<PagedResult<CategoryViewModel>> HandleAsync(GetCategoriesQuery query, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var categoriesQuery = _categoriesRepository.GetQueryable();

            // Filtro opcional por ID
            if (query.Id.HasValue)
            {
                categoriesQuery = categoriesQuery.Where(c => c.Id == query.Id.Value);
            }

            // Filtro opcional por nombre parcial
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

            // Total antes de paginar
            var total = await categoriesQuery.CountAsync(cancellationToken);

            // Paginación
            int pageSize = query.PageSize > 0 ? query.PageSize.Value : 10;
            int pageNumber = query.PageNumber > 0 ? query.PageNumber.Value : 1;

            var page = await categoriesQuery
                .OrderBy(c => c.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            // Mapeo a ViewModel
            var items = page.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Code = c.Code,
                FullCode = "-" // Podés cambiar esto por lógica real
            }).ToList();

            return new PagedResult<CategoryViewModel>
            {
                TotalCount = total,
                Items = items
            };
        }

    }

}
