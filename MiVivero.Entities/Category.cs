using MiVivero.Entities.BaseEntities;

namespace MiVivero.Entities
{
    public class Category : NameableEntity
    {
        public string Code { get; set; }
        public int? ParentId { get; set; }
        public Category? Parent { get; set; }
        public ICollection<Category> ChildCategories { get; set; } = new List<Category>();
    }
}
