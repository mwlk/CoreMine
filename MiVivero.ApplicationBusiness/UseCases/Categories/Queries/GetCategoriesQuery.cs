using MediatR;
using MiVivero.Models.ViewModels;

namespace MiVivero.ApplicationBusiness.UseCases.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<IEnumerable<CategoryViewModel>>
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }
}
