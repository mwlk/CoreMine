using AutoMapper;
using MediatR;
using MiVivero.ApplicationBusiness.UseCases.Products.Queries;
using MiVivero.Models.ViewModels;
using MiVivero.Models.Filters;
using MiVivero.ApplicationBusiness.Interfaces;

namespace MiVivero.ApplicationBusiness.UseCases.Products.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductViewModel>>
    {
        private readonly IProductsRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsHandler(IProductsRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        async Task<IEnumerable<ProductViewModel>> IRequestHandler<GetProductsQuery, IEnumerable<ProductViewModel>>.Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var filter = new ProductFilter
            {
                Id = request.Id,
                Name = request.Name,
                //CategoryIds = request.CategoryIds
            };

            var productEntities = await _productRepository.GetByFilterAsync(filter, cancellationToken);

            var products = _mapper.Map<IEnumerable<ProductViewModel>>(productEntities);
            return products;
        }
    }
}
