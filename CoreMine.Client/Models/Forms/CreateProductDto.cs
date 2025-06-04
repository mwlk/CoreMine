using System.ComponentModel.DataAnnotations;

namespace CoreMine.Client.Models.Forms
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public int ProductCategoryId { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required]
        public int SupplierId { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public int UnitOfMeasureId { get; set; }
    }
}
