using CoreMine.ApplicationBusiness.Common.Pagination;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.PurchaseInvoices.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.DTOs;
using CoreMine.Models.ViewModels;

namespace CoreMine.ApplicationBusiness.UseCases.PurchaseInvoices.Handlers
{
    public class GetPurchaseInvoicesQueryHandler : IQueryHandler<GetPurchaseInvoicesQuery, PagedResult<PurchaseInvoiceViewModel>>
    {
        private readonly IReadOnlyPurchaseInvoicesRepository _repository;

        public GetPurchaseInvoicesQueryHandler(IReadOnlyPurchaseInvoicesRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<PurchaseInvoiceViewModel>> HandleAsync(GetPurchaseInvoicesQuery query, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            int pageSize = query.PageSize.HasValue ? query.PageSize.Value : 10;
            int pageNumber = query.PageNumber > 0 ? query.PageNumber.Value : 1;

            var baseQuery = _repository.GetQueryable();

            if (query.Ids?.Length > 0)
            {
                baseQuery = baseQuery.Where(p => query.Ids.Contains(p.Id));
            }

            if (query.SupplierIds?.Length > 0)
            {
                baseQuery = baseQuery.Where(p => query.SupplierIds.Contains(p.SupplierId));
            }

            if (query.FromDate.HasValue)
            {
                var fromDate = query.FromDate.Value.Date;
                baseQuery = baseQuery.Where(p => p.IngresedAt >= fromDate);
            }

            if (query.ToDate.HasValue)
            {
                var toDate = query.ToDate.Value.Date.AddDays(1).AddTicks(-1);
                baseQuery = baseQuery.Where(p => p.IngresedAt <= toDate);
            }

            var projectedQuery = baseQuery.Select(p => new PurchaseInvoiceViewModel
            {
                Id = p.Id,
                IngresedAt = p.IngresedAt,
                SupplierId = p.SupplierId,
                SupplierName = p.Supplier.Surname,

                Total = p.PurchaseInvoiceDetails.Sum(d => d.UnitPrice * d.Quantity),

                Details = p.PurchaseInvoiceDetails
                    .Where(d => d.Product != null)
                    .Select(d => new PurchaseInvoiceDetailViewModel
                    {
                        ProductId = d.ProductId,
                        ProductCode = d.Product.Code,
                        ProductName = d.Product.Name,
                        Quantity = d.Quantity,
                        UnitPrice = d.UnitPrice,
                    })
                    .OrderBy(d => d.ProductCode)
                    .ToList()
            });

            return await projectedQuery.ToPagedResultAsync(pageNumber, pageSize, cancellationToken);
        }
    }
}
