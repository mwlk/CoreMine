namespace CoreMine.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string FullCode { get; set; } = string.Empty;
        public int? ParentId { get; set; }
    }
}
