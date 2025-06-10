namespace CoreMine.Client.Models.ReadModels
{
    public class SupplierReadModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = default!;
        public string? Contact { get; set; }
        public string Phone { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
