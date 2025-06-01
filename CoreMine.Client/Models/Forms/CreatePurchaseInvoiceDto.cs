using CoreMine.Models.DTOs;

namespace CoreMine.Client.Models.Forms
{
    public class CreatePurchaseInvoiceDto
    {
        public int SupplierId { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime IngresedAt { get; set; }
        public int LocationId { get; set; }
        public List<PurchaseInvoiceDetailDto> Products { get; set; }

        public CreatePurchaseInvoiceDto()
        {
            Products = new List<PurchaseInvoiceDetailDto>();
        }
    }
}
