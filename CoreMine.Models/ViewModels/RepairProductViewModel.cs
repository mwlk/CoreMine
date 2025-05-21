using CoreMine.Models.Common;

namespace CoreMine.Models.ViewModels
{
    public class RepairProductViewModel : TypeBaseViewModel
    {
        public decimal QuantityUsed { get; set; }
        public CategoryViewModel Category { get; set; } = default!;
        public UnitOfMeasureViewModel UnitOfMeasure { get; set; } = default!;
        public decimal UnitPrice { get; set; }
    }
}
