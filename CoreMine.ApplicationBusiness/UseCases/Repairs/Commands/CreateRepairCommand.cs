using CoreMine.Models.DTOs;

namespace CoreMine.ApplicationBusiness.UseCases.Repairs.Commands
{
    public class CreateRepairCommand
    {
        public DateTime StartDate { get; set; }
        public string Description { get; set; } = default!;
        public string? Observations { get; set; }
        public int MachineId { get; set; }
        public List<RepairProductDto> Products { get; set; }
    }
}
