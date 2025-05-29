namespace CoreMine.Models.ViewModels
{
    public class StockViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public string LocationName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
