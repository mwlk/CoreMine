using CoreMine.Entities.BaseEntities;

namespace CoreMine.Entities
{
    public class Location : NameableEntity
    {
        public string Description { get; set; } = null!;
        public virtual ICollection<StockLevel> StockLevels { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<StockMovement> StockMovements { get; set; }

        public Location()
        {
            StockLevels = new HashSet<StockLevel>();
            Stocks = new HashSet<Stock>();
            StockMovements = new HashSet<StockMovement>();
        }
    }
}
