using CoreMine.Entities.BaseEntities;

namespace CoreMine.Entities
{
    public class Machine : BaseEntity
    {
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Repair> Repairs { get; set; }

        public Machine()
        {
            Repairs = new HashSet<Repair>();
        }
    }

}
