namespace CoreMine.Data.ReadModels
{
    public class RepairWithProductsReadModel
    {
        public int RepairId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; } = default!;
        public string? Observations { get; set; }

        public int MachineId { get; set; }
        public string MachineDescription { get; set; } = default!;
        public string MachineCode { get; set; } = default!;
        public bool MachineIsActive { get; set; }

        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? QuantityUsed { get; set; }

        public int? CategoryId { get; set; }
        public string? CategoryCode { get; set; }
        public string? CategoryName { get; set; }

        public int? UnitOfMeasureId { get; set; }
        public string? UnitOfMeasureName { get; set; }
        public string? UnitOfMeasureSymbol { get; set; }
    }
}
