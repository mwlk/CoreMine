using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.UseCases.Categories.Queries;
using CoreMine.Entities;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;

namespace CoreMine.ApplicationBusiness.UseCases.Categories.Handlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, PagedResult<CategoryViewModel>>
    {
        private readonly IReadOnlyCategoriesRepository _categoriesRepository;

        public GetCategoriesHandler(IReadOnlyCategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<PagedResult<CategoryViewModel>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = _categoriesRepository.GetQueryable();

            // Filtro opcional por ID
            if (request.Id.HasValue)
            {
                query = query.Where(c => c.Id == request.Id.Value);
            }

            // Filtro opcional por nombre parcial
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(c => c.Name.Contains(request.Name));
            }

            if (request.ParentId.HasValue)
            {
                query = query.Where(p => p.ParentId == request.ParentId);
            }

            if (request.IsParent.HasValue)
            {
                query = query.Where(p => !p.ParentId.HasValue == request.IsParent.Value);
            }

            // Total antes de paginar
            var total = await query.CountAsync(cancellationToken);

            // Paginación
            int pageSize = request.PageSize > 0 ? request.PageSize.Value : 10;
            int pageNumber = request.PageNumber > 0 ? request.PageNumber.Value : 1;

            var page = await query
                .OrderBy(c => c.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            // Mapeo a tu ViewModel
            var items = page.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Code = c.Code,
                FullCode = c.FullCode
            }).ToList();

            return new PagedResult<CategoryViewModel>
            {
                TotalCount = total,
                Items = items
            };
        }
    }

}
