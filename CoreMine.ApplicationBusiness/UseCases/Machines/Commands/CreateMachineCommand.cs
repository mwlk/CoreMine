namespace CoreMine.ApplicationBusiness.UseCases.Machines.Commands
{
    public class CreateMachineCommand
    {
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
    }
}
