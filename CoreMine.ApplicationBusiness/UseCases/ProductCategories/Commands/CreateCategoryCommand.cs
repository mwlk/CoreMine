namespace CoreMine.ApplicationBusiness.UseCases.Categories.Commands
{
    public class CreateCategoryCommand 
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public int? ParentId { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException("El nombre es obligatorio");
            }

            if (string.IsNullOrEmpty(Code))
            {
                throw new ArgumentException("El código es obligatorio");
            }
        }
    }
}
