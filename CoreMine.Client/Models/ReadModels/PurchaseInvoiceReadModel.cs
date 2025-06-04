namespace CoreMine.Client.Models.ReadModels
{
    public class PurchaseInvoiceReadModel
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public DateTime IngresedAt { get; set; }
        public decimal Total { get; set; }
        public List<PurchaseInvoiceDetailReadModel> Details { get; set; }

        public PurchaseInvoiceReadModel()
        {
            Details = new List<PurchaseInvoiceDetailReadModel>();
        }
    }

    public class PurchaseInvoiceDetailReadModel
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
