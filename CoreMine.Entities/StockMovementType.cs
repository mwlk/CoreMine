namespace CoreMine.Entities
{
    public class StockMovementType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsPositive { get; set; }
        public virtual ICollection<StockMovement> StockMovements { get; set; }

        public StockMovementType()
        {
            StockMovements = new HashSet<StockMovement>();
        }
    }
}

