using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMine.Data.Configurations
{
    public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            builder.ToTable("StockMovements");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Id);

            builder.Property(p => p.ProductId)
                .IsRequired();

            builder.Property(p => p.LocationId)
                .IsRequired();

            builder.Property(p => p.StockMovementTypeId)
                .IsRequired();

            builder.Property(p => p.Quantity)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(p => p.Product)
               .WithMany(p => p.StockMovements)
               .HasForeignKey(p => p.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Location)
                .WithMany(p => p.StockMovements)
                .HasForeignKey(p => p.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
