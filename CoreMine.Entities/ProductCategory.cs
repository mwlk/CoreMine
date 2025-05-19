using CoreMine.Entities.BaseEntities;

namespace CoreMine.Entities
{
    public class ProductCategory : NameableEntity
    {
        public string Code { get; set; } = null!;
        public int? ParentId { get; set; }
        public ProductCategory? Parent { get; set; }
        public ICollection<ProductCategory> ChildCategories { get; set; } = new List<ProductCategory>();
    }
}
