using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMine.Data.Configurations
{
    public class ProductStateConfiguration : IEntityTypeConfiguration<ProductState>
    {
        public void Configure(EntityTypeBuilder<ProductState> builder)
        {
            builder.ToTable("ProductStates");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.ProductStateTypeId)
                .IsRequired();

            builder.Property(p => p.Observations)
                .HasMaxLength(200);
        }
    }
}
