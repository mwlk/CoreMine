using CoreMine.Entities.BaseEntities;

namespace CoreMine.Entities
{
    public class Location : NameableEntity
    {
        public string Description { get; set; } = null!;
        public virtual ICollection<StockLevel> StockLevels { get; set; }

        public Location()
        {
            StockLevels = new HashSet<StockLevel>();
        }
    }
}
