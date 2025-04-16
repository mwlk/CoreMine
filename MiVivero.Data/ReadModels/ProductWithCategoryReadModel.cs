namespace MiVivero.Data.ReadModels
{
    public class ProductWithCategoryReadModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string FullCode { get; set; } = string.Empty;
        public string FullCategoryPath { get; set; } = string.Empty;
    }
}
