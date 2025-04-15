using AutoMapper;
using MediatR;
using MiVivero.ApplicationBusiness.Interfaces;
using MiVivero.ApplicationBusiness.UseCases.Categories.Queries;
using MiVivero.Models.Filters;
using MiVivero.Models.ViewModels;

namespace MiVivero.ApplicationBusiness.UseCases.Categories.Handlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryViewModel>>
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;

        public GetCategoriesHandler(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryViewModel>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var filter = new CategoryFilter
            {
                Id = request.Id,
                Name = request.Name
            };

            var categoryEntities = await _categoriesRepository.GetByFilterAsync(filter, cancellationToken);

            var products = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryEntities);
            return products;
        }
    }

}
