using CoreMine.Entities.BaseEntities;

namespace CoreMine.Entities
{
    public class Supplier : NameableEntity
    {
        public string Surname { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
