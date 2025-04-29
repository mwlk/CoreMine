namespace CoreMine.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string FullCode { get; set; } = string.Empty;
    }
}
