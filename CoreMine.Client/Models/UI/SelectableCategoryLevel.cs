using CoreMine.Models.ViewModels;

namespace CoreMine.Client.Models.UI
{
    public class SelectableCategoryLevel
    {
        public List<CategoryViewModel> Options { get; set; } = new();
        public int? SelectedCategoryId { get; set; }
    }
}
