namespace CoreMine.Models.DTOs
{
    public class PurchaseInvoiceDetailDto
    {
        public string ProductCode { get; set; } = default!;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
