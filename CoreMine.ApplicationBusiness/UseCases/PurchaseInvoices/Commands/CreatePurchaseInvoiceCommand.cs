using CoreMine.Models.DTOs;

namespace CoreMine.ApplicationBusiness.UseCases.PurchaseInvoices.Commands
{
    public class CreatePurchaseInvoiceCommand
    {
        public int SupplierId { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        private DateTime _ingresedAt;
        public DateTime IngresedAt { get; set; }
        public int LocationId { get; set; }
        public List<PurchaseInvoiceDetailDto> Products { get; set; }

        public CreatePurchaseInvoiceCommand()
        {
            Products = new List<PurchaseInvoiceDetailDto>();
        }
    }
}
