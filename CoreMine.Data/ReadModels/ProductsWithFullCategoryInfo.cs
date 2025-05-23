namespace CoreMine.Data.ReadModels
{
    public class ProductsWithFullCategoryInfoReadModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        public string? FullCategoryCode { get; set; }
        public string? SupplierName { get; set; }
        public decimal UnitPrice { get; set; }
        public string? UnitOfMeasureName { get; set; }
        public string? LastStateTypeName { get; set; }
        public int? LocationId { get; set; }
        public string? LocationName { get; set; }
        public decimal? MaxQuantity { get; set; }
        public decimal? MinQuantity { get; set; }
        public decimal? Quantity { get; set; }
    }
}
