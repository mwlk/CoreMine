using CoreMine.Entities.BaseEntities;

namespace CoreMine.Entities
{
    public class Repair : BaseEntity
    {
        public int MachineId { get; set; }
        public Machine Machine { get; set; } = null!;

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Description { get; set; } = null!;
        public string? Observations { get; set; }

        public ICollection<RepairProduct> RepairProducts { get; set; }

        public Repair()
        {
            RepairProducts = new HashSet<RepairProduct>();
        }
    }

}
