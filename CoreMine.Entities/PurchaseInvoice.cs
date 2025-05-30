namespace CoreMine.Entities
{
    public class PurchaseInvoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime IngresedAt { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;
        public virtual ICollection<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }

        public PurchaseInvoice()
        {
            PurchaseInvoiceDetails = new HashSet<PurchaseInvoiceDetail>();
        }
    }
}
