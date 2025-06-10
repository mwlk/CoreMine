using CoreMine.Entities.BaseEntities;

namespace CoreMine.Entities
{
    public class Supplier : NameableEntity
    {
        public string Surname { get; set; } = null!;
        public string? Contact { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; }

        public Supplier()
        {
            Products = new HashSet<Product>();
            PurchaseInvoices = new HashSet<PurchaseInvoice>();
        }
    }
}
