namespace CoreMine.Entities
{
    public class PurchaseInvoiceDetail
    {
        public int Id { get; set; }
        public int PurchaseInvoiceId { get; set; }
        public PurchaseInvoice PurchaseInvoice { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
