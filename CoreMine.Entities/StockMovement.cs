using CoreMine.Entities.BaseEntities;

namespace CoreMine.Entities
{
    public class StockMovement : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public int StockMovementTypeId { get; set; }
        public StockMovementType StockMovementType { get; set; } = null!;
        public decimal Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Observations { get; set; } = null!;
    }
}
