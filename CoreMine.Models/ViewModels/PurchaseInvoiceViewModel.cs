namespace CoreMine.Models.ViewModels
{
    public class PurchaseInvoiceViewModel
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public DateTime IngresedAt { get; set; }
        public decimal Total { get; set; }
        public List<PurchaseInvoiceDetailViewModel> Details { get; set; }

        public PurchaseInvoiceViewModel()
        {
            Details = new List<PurchaseInvoiceDetailViewModel>();
        }

    }
}
