using System.ComponentModel.DataAnnotations;

namespace CoreMine.Client.Models.Forms
{
    public class CreateRepairDto
    {
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Descripción es obligatoria")]
        public string Description { get; set; } = default!;
        public string? Observations { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una maquinaria")]
        public int MachineId { get; set; }
        [Required]
        public List<RepairProductDto> Products { get; set; }
        public int? LocationId { get; set; }

        public CreateRepairDto()
        {
            Products = new List<RepairProductDto>();
        }
    }
}
