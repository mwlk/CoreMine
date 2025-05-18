using CoreMine.Entities.BaseEntities;

namespace CoreMine.Entities
{
    public class Stock : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public decimal Quantity { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
