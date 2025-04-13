using AutoMapper;
using MediatR;
using MiVivero.ApplicationBusiness.Interfaces;
using MiVivero.ApplicationBusiness.UseCases.Products.Commands;
using MiVivero.Entities;

namespace MiVivero.ApplicationBusiness.UseCases.Products.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Unit>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public AddProductHandler(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            if (request.ProductToAdd == null)
            {
                throw new NotImplementedException();
            }

            var productEntity = _mapper.Map<Product>(request.ProductToAdd);

            await _productRepository.AddAsync(productEntity, cancellationToken);

            return Unit.Value;
        }
    }
}
