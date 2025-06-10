using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMine.Data.Configurations
{
    public class StockLevelConfiguration : IEntityTypeConfiguration<StockLevel>
    {
        public void Configure(EntityTypeBuilder<StockLevel> builder)
        {
            builder.ToTable("StockLevels");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Id);

            builder.Property(p => p.MaxQuantity)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.MinQuantity)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.DefinedAt)
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(p => p.Product)
                .WithMany(p => p.StockLevels)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Location)
                .WithMany(p => p.StockLevels)
                .HasForeignKey(p => p.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
