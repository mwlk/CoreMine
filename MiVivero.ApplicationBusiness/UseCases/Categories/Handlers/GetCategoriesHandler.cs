using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MiVivero.ApplicationBusiness.Interfaces;
using MiVivero.ApplicationBusiness.Interfaces.ReadOnly;
using MiVivero.ApplicationBusiness.UseCases.Categories.Queries;
using MiVivero.Entities;
using MiVivero.Models.Common;
using MiVivero.Models.ViewModels;

namespace MiVivero.ApplicationBusiness.UseCases.Categories.Handlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, PagedResult<CategoryViewModel>>
    {
        private readonly IReadOnlyCategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;

        public GetCategoriesHandler(IReadOnlyCategoriesRepository categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CategoryViewModel>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query =  _categoriesRepository.GetQueryable();

           

            if (request.Id.HasValue)
            {
                query = query.Where(p => p.Id == request.Id.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(p => request.Name.Contains(p.Name));
            }



            var count = await query.CountAsync(cancellationToken);

            int pageSize = request.PageSize.HasValue && request.PageSize.Value > 0 ? request.PageSize.Value : 10;
            int pageNumber = request.PageNumber.HasValue && request.PageNumber.Value > 0 ? request.PageNumber.Value : 1;

            var paginated = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(p => p.Id)
                .ToListAsync(cancellationToken);

            var result = _mapper.Map<IEnumerable<CategoryViewModel>>(paginated);

            return new PagedResult<CategoryViewModel>
            {
                TotalCount = count,
                Items = result
            };
        }
    }

}
