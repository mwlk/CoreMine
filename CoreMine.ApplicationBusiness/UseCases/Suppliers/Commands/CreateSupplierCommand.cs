namespace CoreMine.ApplicationBusiness.UseCases.Suppliers.Commands
{
    public class CreateSupplierCommand
    {
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string? Contact { get; set; }
        public string Phone { get; set; } = default!;

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException("El nombre es obligatorio");
            }

            if (string.IsNullOrEmpty(Surname))
            {
                throw new ArgumentException("El apellido es obligatorio");
            }

            if (string.IsNullOrEmpty(Phone))
            {
                throw new ArgumentException("El teléfono es obligatorio");
            }
        }
    }
}
