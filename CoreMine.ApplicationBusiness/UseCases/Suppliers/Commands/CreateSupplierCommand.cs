namespace CoreMine.ApplicationBusiness.UseCases.Suppliers.Commands
{
    public class CreateSupplierCommand
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? BusinessName { get; set; }
        public string? TradeName { get; set; }
        public string? Contact { get; set; }
        public string Phone { get; set; } = default!;

        public void Validate()
        {
            ValidateIdentity();
            ValidatePhone();
        }

        private void ValidatePhone()
        {
            if (string.IsNullOrWhiteSpace(Phone))
            {
                throw new ArgumentException("El teléfono es obligatorio.");
            }
        }

        private void ValidateIdentity()
        {
            var isPhysicalPerson = !string.IsNullOrWhiteSpace(Name) || !string.IsNullOrWhiteSpace(Surname);
            var isLegalPerson = !string.IsNullOrWhiteSpace(TradeName);

            if (isPhysicalPerson && isLegalPerson)
            {
                throw new ArgumentException("No puede ser persona física y jurídica al mismo tiempo.");
            }

            if (!isPhysicalPerson && !isLegalPerson)
            {
                throw new ArgumentException("Debe ingresar nombre y apellido (persona física) o razón social (persona jurídica).");
            }

            if (isPhysicalPerson)
            {
                if (string.IsNullOrWhiteSpace(Name))
                    throw new ArgumentException("El nombre es obligatorio para personas físicas.");
                if (string.IsNullOrWhiteSpace(Surname))
                    throw new ArgumentException("El apellido es obligatorio para personas físicas.");
            }
        }
    }

}
