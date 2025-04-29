using Microsoft.EntityFrameworkCore;

namespace CoreMine.Data.ReadModels
{
    [Keyless]
    public class ProductWithCategoryReadModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int AncestorCategoryId { get; set; }
        public string FullCategoryPath { get; set; } = string.Empty;
        public string FullCategoryCode { get; set; } = string.Empty;
    }
}
