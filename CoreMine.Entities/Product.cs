using CoreMine.Entities.BaseEntities;

namespace CoreMine.Entities
{
    public class Product : NameableEntity
    {
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; } = null!;
        public string? Description { get; set; }
        public string Code { get; set; }
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public double UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModificatedAt { get; set; }
        public int UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; } = null!;
        public virtual ICollection<ProductState> ProductStates { get; set; }
        public virtual ICollection<StockLevel> StockLevels { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<StockMovement> StockMovements { get; set; }

        public Product()
        {
            ProductStates = new HashSet<ProductState>();
            StockLevels = new HashSet<StockLevel>();
            Stocks = new HashSet<Stock>();
            StockMovements = new HashSet<StockMovement>();
        }
    }
}
