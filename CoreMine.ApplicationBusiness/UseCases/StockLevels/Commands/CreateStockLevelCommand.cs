namespace CoreMine.ApplicationBusiness.UseCases.StockLevels.Commands
{
    public class CreateStockLevelCommand
    {
        public int ProductId { get; set; }
        public int LocationId { get; set; }
        public decimal MaxQuantity { get; set; }
        public decimal MinQuantity { get; set; }

        public void Validate()
        {
            if (MaxQuantity <= 0)
            {
                throw new ArgumentException("El máximo de la configuración debe ser mayor a 0.");
            }

            if (MinQuantity < 0)
            {
                throw new ArgumentException("El mínimo de la configuración no puede ser negativo.");
            }

            if (MinQuantity > MaxQuantity)
            {
                throw new ArgumentException("El mínimo no puede ser mayor al máximo.");
            }
        }
    }
}
