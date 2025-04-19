using MediatR;
using MiVivero.Models.Common;
using MiVivero.Models.ViewModels;

namespace MiVivero.ApplicationBusiness.UseCases.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<PagedResult<CategoryViewModel>>
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public bool? IsParent { get; set; } = false;
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}
