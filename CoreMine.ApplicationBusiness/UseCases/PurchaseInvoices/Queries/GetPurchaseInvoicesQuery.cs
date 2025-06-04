using CoreMine.ApplicationBusiness.Common.Queries;

namespace CoreMine.ApplicationBusiness.UseCases.PurchaseInvoices.Queries
{
    public class GetPurchaseInvoicesQuery : PaginatedQuery
    {
        public int[]? Ids { get; set; }
        public int[]? SupplierIds { get; set; }
    }
}
