using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMine.Data.Configurations
{
    public class StockMovementTypeConfiguration : IEntityTypeConfiguration<StockMovementType>
    {
        public void Configure(EntityTypeBuilder<StockMovementType> builder)
        {
            builder.ToTable("StockMovementTypes");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.IsPositive)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}
