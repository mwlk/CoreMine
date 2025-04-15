using AutoMapper;
using MediatR;
using MiVivero.ApplicationBusiness.Interfaces;
using MiVivero.ApplicationBusiness.UseCases.Categories.Queries;
using MiVivero.Entities;
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

            var categories = await _categoriesRepository.GetWithParentsAsync(filter, cancellationToken);

            var categoryMap = categories.ToDictionary(c => c.Id);

            string GetFullCode(Category category)
            {
                var visited = new HashSet<int>();
                var codes = new List<string>();
                var current = category;

                while (current != null)
                {
                    if (!visited.Add(current.Id))
                        throw new InvalidOperationException("Ciclo detectado en la jerarquía de categorías.");

                    codes.Insert(0, current.Code);

                    current = current.ParentId.HasValue && categoryMap.TryGetValue(current.ParentId.Value, out var parent)
                        ? parent
                        : null;
                }

                return string.Join(".", codes);
            }

            var result = categories.Select(cat =>
            {
                var vm = _mapper.Map<CategoryViewModel>(cat);
                vm.FullCode = GetFullCode(cat);
                return vm;
            });

            return result;
        }
    }

}
