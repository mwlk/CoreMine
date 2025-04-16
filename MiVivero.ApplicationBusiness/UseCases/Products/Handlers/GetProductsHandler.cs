using AutoMapper;
using MediatR;
using MiVivero.ApplicationBusiness.UseCases.Products.Queries;
using MiVivero.Models.ViewModels;
using MiVivero.Models.Filters;
using MiVivero.ApplicationBusiness.Interfaces;
using Microsoft.EntityFrameworkCore;
using MiVivero.Models.Common;
using System.Linq;

namespace MiVivero.ApplicationBusiness.UseCases.Products.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, PagedResult<ProductViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IReadOnlyProductsRepository _repository;

        public GetProductsHandler(IMapper mapper, IReadOnlyProductsRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResult<ProductViewModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var filter = new ProductFilter
            {
                Id = request.Id,
                Name = request.Name,
            };

            var query = _repository
                .GetQueryable();

            if (filter.Id.HasValue)
            {
                query = query.Where(p => p.ProductId == filter.Id);
            }

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.ProductName.Contains(filter.Name));
            }

            var count = await query.CountAsync(cancellationToken);

            int pageSize = request.PageSize.HasValue && request.PageSize.Value > 0 ? request.PageSize.Value : 10;
            int pageNumber = request.PageNumber.HasValue && request.PageNumber.Value > 0 ? request.PageNumber.Value : 1;

            var paginated = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(p => p.ProductId)
                .ToListAsync(cancellationToken);

            var result = _mapper.Map<IEnumerable<ProductViewModel>>(paginated);

            return new PagedResult<ProductViewModel>
            {
                TotalCount = count,
                Items = result
            };
        }
    }
}
