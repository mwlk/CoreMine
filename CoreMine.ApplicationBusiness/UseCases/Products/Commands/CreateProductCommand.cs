using CoreMine.Models.DTOs;

namespace CoreMine.ApplicationBusiness.UseCases.Products.Commands
{
    public class CreateProductCommand 
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int ProductCategoryId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int SupplierId { get; set; }
        public double UnitPrice { get; set; }
        public int UnitOfMeasureId { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("El nombre del producto es requerido");
            }

            if (string.IsNullOrEmpty(Code) || string.IsNullOrWhiteSpace(Code))
            {
                throw new ArgumentException("El código es requerido");
            }

            if (UnitPrice < 0)
            {
                throw new ArgumentException("El precio unitario debe ser mayor a 0");
            }
        }
    }
}
