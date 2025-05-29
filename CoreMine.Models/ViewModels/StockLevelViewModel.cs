namespace CoreMine.Models.ViewModels
{
    public class StockLevelViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public string LocationName { get; set; } = string.Empty;
        public decimal MaxQuantity { get; set; }
        public decimal MinQuantity { get; set; }
        public DateTime DefinedAt { get; set; }
    }
}
