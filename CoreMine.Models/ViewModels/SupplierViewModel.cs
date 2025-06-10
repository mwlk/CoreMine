using CoreMine.Models.Common;

namespace CoreMine.Models.ViewModels
{
    public class SupplierViewModel : IdentifiableViewModel
    {
        public string FullName { get; set; } = default!;
        public string? Contact { get; set; }
        public string Phone { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
