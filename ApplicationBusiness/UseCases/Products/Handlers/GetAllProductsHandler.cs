using AutoMapper;
using MediatR;
using MiVivero.ApplicationBusiness.Interfaces;
using MiVivero.ApplicationBusiness.UseCases.Categories.Queries;
using MiVivero.ApplicationBusiness.UseCases.Products.Queries;
using MiVivero.Entities;
using MiVivero.Models.ViewModels;

namespace MiVivero.ApplicationBusiness.UseCases.Products.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductViewModel>>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        async Task<IEnumerable<ProductViewModel>> IRequestHandler<GetAllProductsQuery, IEnumerable<ProductViewModel>>.Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productEntities = await _productRepository.GetAllAsync(cancellationToken);

            var products = _mapper.Map<IEnumerable<ProductViewModel>>(productEntities);
            return products;
        }
    }
}
