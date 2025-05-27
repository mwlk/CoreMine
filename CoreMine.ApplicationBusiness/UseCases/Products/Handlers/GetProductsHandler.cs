using CoreMine.ApplicationBusiness.Common.Pagination;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Products.Queries;
using CoreMine.Data.ReadModels;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.ApplicationBusiness.UseCases.Products.Handlers
{
    public class GetProductsHandler : IQueryHandler<GetProductsQuery, PagedResult<ProductsWithFullCategoryInfoReadModel>>
    {
        private readonly IReadOnlyProductsRepository _repository;

        public GetProductsHandler(IReadOnlyProductsRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<ProductsWithFullCategoryInfoReadModel>> HandleAsync(GetProductsQuery query, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            int pageSize = query.PageSize > 0 ? query.PageSize.Value : 10;
            int pageNumber = query.PageNumber > 0 ? query.PageNumber.Value : 1;

            var baseQuery = _repository.GetQueryable();

            if (query.Id.HasValue)
            {
                baseQuery = baseQuery.Where(p => p.Id == query.Id);
            }

            if (query.CategoryIds?.Length > 0)
            {
                baseQuery = baseQuery.Where(p =>
                    query.CategoryIds.Any(id => p.FullCategoryCode.Contains("/" + id + "/") ||
                                                p.FullCategoryCode.EndsWith("/" + id) ||
                                                p.FullCategoryCode == id.ToString()));
            }

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                baseQuery = baseQuery.Where(p => p.Name.Contains(query.Name));
            }

            var mapped = baseQuery
                .OrderBy(p => p.Id)
                .Select(p => new ProductsWithFullCategoryInfoReadModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Code = p.Code,
                    CategoryId = p.CategoryId,
                    CategoryName = p.CategoryName,
                    FullCategoryCode = p.FullCategoryCode,
                    SupplierName = p.SupplierName,
                    UnitPrice = p.UnitPrice,
                    UnitOfMeasureName = p.UnitOfMeasureName,
                    LastStateTypeId = p.LastStateTypeId,
                    LastStateTypeName = p.LastStateTypeName,
                    LocationId = p.LocationId,
                    LocationName = p.LocationName,
                    MaxQuantity = p.MaxQuantity,
                    MinQuantity = p.MinQuantity,
                    Quantity = p.Quantity
                });

            return await mapped.ToPagedResultAsync(pageNumber, pageSize, cancellationToken);
        }
    }
}
