using CoreMine.Models.DTOs;

namespace CoreMine.ApplicationBusiness.UseCases.PurchaseInvoices.Commands
{
    public class CreatePurchaseInvoiceCommand
    {
        public int SupplierId { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        private DateTime _ingresedAt;
        public DateTime IngresedAt
        {
            get => _ingresedAt;
            set
            {
                if (value == DateTime.MinValue || value <= new DateTime(1753, 1, 1))
                {
                    _ingresedAt = DateTime.Now.Date;
                }
                else
                {
                    _ingresedAt = value;
                }
            }
        }
        public int LocationId { get; set; }
        public List<PurchaseInvoiceDetailDto> Products { get; set; }

        public CreatePurchaseInvoiceCommand()
        {
            Products = new List<PurchaseInvoiceDetailDto>();
        }
    }
}
