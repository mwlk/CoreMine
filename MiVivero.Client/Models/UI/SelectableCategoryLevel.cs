using MiVivero.Models.ViewModels;

namespace MiVivero.Client.Models.UI
{
    public class SelectableCategoryLevel
    {
        public List<CategoryViewModel> Options { get; set; } = new();
        public int? SelectedCategoryId { get; set; }
    }
}
