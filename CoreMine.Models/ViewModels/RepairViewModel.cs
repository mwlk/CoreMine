namespace CoreMine.Models.ViewModels
{
    public class RepairViewModel
    {
        public int Id { get; set; }
        public MachineViewModel Machine { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; } = default!;
        public string? Observations { get; set; }
        public List<RepairProductViewModel> Products { get; set; }

        public RepairViewModel()
        {
            Products = new List<RepairProductViewModel>();
        }
    }
}
