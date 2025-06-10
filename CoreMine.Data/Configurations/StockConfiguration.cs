using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMine.Data.Configurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Id);

            builder.Property(p => p.ProductId)
                .IsRequired();

            builder.Property(p => p.LocationId)
                .IsRequired();

            builder.Property(p => p.Quantity)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.UpdatedAt)
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(p => p.Product)
                .WithMany(p => p.Stocks)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Location)
                .WithMany(p => p.Stocks)
                .HasForeignKey(p => p.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
