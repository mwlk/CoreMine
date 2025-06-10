using System.ComponentModel.DataAnnotations;

namespace CoreMine.Client.Models.Forms
{
    public class RepairProductDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public decimal QuantityUsed { get; set; }
    }
}
