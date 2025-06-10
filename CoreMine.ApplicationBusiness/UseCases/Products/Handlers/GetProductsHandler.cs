using CoreMine.ApplicationBusiness.Common.Pagination;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Products.Queries;
using CoreMine.Data.ReadModels;
using CoreMine.Models.Common;

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

            int pageSize = query.PageSize.HasValue ? query.PageSize.Value : 10;
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

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                var searchTerm = query.Search.Trim();
                baseQuery = baseQuery.Where(p =>
                    p.Name.Contains(searchTerm) ||
                    p.Code.Contains(searchTerm) ||
                    p.CategoryName.Contains(searchTerm) ||
                    p.SupplierName.Contains(searchTerm) ||
                    p.LocationName.Contains(searchTerm) ||
                    p.UnitOfMeasureName.Contains(searchTerm) ||
                    p.LastStateTypeName.Contains(searchTerm) ||
                    p.Description.Contains(searchTerm)
                );
            }

            if (!string.IsNullOrWhiteSpace(query.Code))
            {
                baseQuery = baseQuery.Where(p => p.Code.Contains(query.Code));
            }

            if (!string.IsNullOrWhiteSpace(query.CategoryName))
            {
                baseQuery = baseQuery.Where(p => p.CategoryName.Contains(query.CategoryName));
            }

            if (!string.IsNullOrWhiteSpace(query.SupplierName))
            {
                baseQuery = baseQuery.Where(p => p.SupplierName.Contains(query.SupplierName));
            }

            if (!string.IsNullOrWhiteSpace(query.LocationName))
            {
                baseQuery = baseQuery.Where(p => p.LocationName.Contains(query.LocationName));
            }

            if (!string.IsNullOrWhiteSpace(query.State))
            {
                baseQuery = baseQuery.Where(p => p.LastStateTypeName.Contains(query.State));
            }

            if (query.MinPrice.HasValue)
            {
                baseQuery = baseQuery.Where(p => p.UnitPrice >= query.MinPrice);
            }

            if (query.MaxPrice.HasValue)
            {
                baseQuery = baseQuery.Where(p => p.UnitPrice <= query.MaxPrice);
            }

            if (query.MinStock.HasValue)
            {
                baseQuery = baseQuery.Where(p => p.Quantity >= query.MinStock);
            }

            if (query.MaxStock.HasValue)
            {
                baseQuery = baseQuery.Where(p => p.Quantity <= query.MaxStock);
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

            mapped = ApplySorting(mapped, query.SortBy, query.SortDirection);

            return await mapped.ToPagedResultAsync(pageNumber, pageSize, cancellationToken);
        }

        private IQueryable<ProductsWithFullCategoryInfoReadModel> ApplySorting(
            IQueryable<ProductsWithFullCategoryInfoReadModel> query,
            string? sortBy,
            string? sortDirection)
        {
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                return query.OrderBy(p => p.Id); // Default
            }

            bool descending = !string.IsNullOrWhiteSpace(sortDirection) &&
                             sortDirection.ToLower() == "desc";

            return sortBy.ToLower() switch
            {
                "id" => descending ? query.OrderByDescending(p => p.Id) : query.OrderBy(p => p.Id),
                "name" => descending ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name),
                "code" => descending ? query.OrderByDescending(p => p.Code) : query.OrderBy(p => p.Code),
                "categoryname" => descending ? query.OrderByDescending(p => p.CategoryName) : query.OrderBy(p => p.CategoryName),
                "suppliername" => descending ? query.OrderByDescending(p => p.SupplierName) : query.OrderBy(p => p.SupplierName),
                "unitprice" => descending ? query.OrderByDescending(p => p.UnitPrice) : query.OrderBy(p => p.UnitPrice),
                "quantity" => descending ? query.OrderByDescending(p => p.Quantity) : query.OrderBy(p => p.Quantity),
                "minquantity" => descending ? query.OrderByDescending(p => p.MinQuantity) : query.OrderBy(p => p.MinQuantity),
                "maxquantity" => descending ? query.OrderByDescending(p => p.MaxQuantity) : query.OrderBy(p => p.MaxQuantity),
                "locationname" => descending ? query.OrderByDescending(p => p.LocationName) : query.OrderBy(p => p.LocationName),
                "laststtetypename" => descending ? query.OrderByDescending(p => p.LastStateTypeName) : query.OrderBy(p => p.LastStateTypeName),
                _ => query.OrderBy(p => p.Id)
            };
        }

    }
}
