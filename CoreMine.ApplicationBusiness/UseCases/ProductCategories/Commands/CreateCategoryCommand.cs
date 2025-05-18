namespace CoreMine.ApplicationBusiness.UseCases.Categories.Commands
{
    public class CreateCategoryCommand 
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int? ParentId { get; set; }
    }
}
