namespace CoreMine.Entities
{
    public class RepairProduct
    {
        public int RepairId { get; set; }
        public Repair Repair { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public decimal QuantityUsed { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
