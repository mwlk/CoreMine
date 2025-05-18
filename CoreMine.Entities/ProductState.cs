using CoreMine.Entities.BaseEntities;

namespace CoreMine.Entities
{
    public class ProductState : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int ProductStateTypeId { get; set; }
        public ProductStateType ProductStateType { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string Observations { get; set; } = null!;
    }
}
