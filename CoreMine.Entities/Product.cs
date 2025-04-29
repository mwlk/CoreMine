using CoreMine.Entities.BaseEntities;

namespace CoreMine.Entities
{
    public class Product : NameableEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
