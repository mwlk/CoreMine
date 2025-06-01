namespace CoreMine.Data.ReadModels
{
    public class CategoryWithFullCodeReadModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string FullCategoryCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int? ParentId { get; set; }
    }
}
