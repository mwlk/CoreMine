using CoreMine.Entities.BaseEntities;

namespace CoreMine.Entities
{
    public class ProductStateType : NameableEntity
    {
        public virtual ICollection<ProductState> ProductStates { get; set; }

        public ProductStateType()
        {
            ProductStates = new HashSet<ProductState>();
        }
    }
}
