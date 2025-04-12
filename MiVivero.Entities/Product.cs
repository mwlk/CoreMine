using MiVivero.Entities.BaseEntities;

namespace MiVivero.Entities
{
    public class Product : NameableEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
