using MediatR;

namespace MiVivero.ApplicationBusiness.UseCases.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int? ParentId { get; set; }
    }
}
