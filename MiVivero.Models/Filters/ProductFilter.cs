namespace MiVivero.Models.Filters
{
    public class ProductFilter
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<int> CategoryIds { get; set; } = new List<int>();
    }
}
