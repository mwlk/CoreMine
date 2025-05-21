using CoreMine.Models.Common;

namespace CoreMine.Models.ViewModels
{
    public class MachineViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public DateTime AdquisitionDate { get; set; }
        public bool IsActive { get; set; }
    }
}
