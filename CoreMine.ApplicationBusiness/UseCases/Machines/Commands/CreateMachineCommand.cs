namespace CoreMine.ApplicationBusiness.UseCases.Machines.Commands
{
    public class CreateMachineCommand
    {
        public string Code { get; set; } = default!;
        public string? Description { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Code))
                throw new ArgumentException("El código es obligatorio.");

            if (Description != null && Description.Length > 200)
                throw new ArgumentException("La descripción no puede tener más de 200 caracteres.");
        }
    }
}
