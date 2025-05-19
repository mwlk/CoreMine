using CoreMine.Entities.BaseEntities;

namespace CoreMine.Entities
{
    public class StockLevel : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public decimal MaxQuantity { get; set; }
        public decimal MinQuantity { get; set; }
        public DateTime DefinedAt { get; set; }
    }
}
