using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.UseCases.Products.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;

namespace CoreMine.ApplicationBusiness.UseCases.Products.Handlers
{
    public class GetProductsHandler 
    {
        private readonly IReadOnlyProductsRepository _repository;

        public GetProductsHandler(IReadOnlyProductsRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<ProductViewModel>> Handle(
        GetProductsQuery request,
        CancellationToken cancellationToken)
        {
            // Convertir lista de int a CSV para pasar al SQL
            var ancestorIdsCsv = request.CategoryIds is { Count: > 0 }
                ? string.Join(',', request.CategoryIds)
                : "";
            var ancestorCount = request.CategoryIds?.Count ?? 0;

            // Cálculo de skip/take
            int pageSize = request.PageSize > 0 ? request.PageSize.Value : 10;
            int pageNumber = request.PageNumber > 0 ? request.PageNumber.Value : 1;
            int skip = (pageNumber - 1) * pageSize;

            // Llamada al repositorio
            var (total, rows) = await _repository
                .GetProductsByHierarchyAsync(
                    request.Name,
                    ancestorIdsCsv,
                    ancestorCount,
                    skip,
                    pageSize,
                    cancellationToken);

            // Mapeo a ViewModel
            var items = rows.Select(x => new ProductViewModel
            {
                Id = x.ProductId,
                Name = x.ProductName,
                CategoryName = x.FullCategoryPath,
                FullCategoryCode = x.FullCategoryCode
            }).ToList();

            return new PagedResult<ProductViewModel>
            {
                TotalCount = total,
                Items = items
            };
        }
    }
}
