using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMine.Data.Configurations
{
    public class ProductStateTypeConfiguration : IEntityTypeConfiguration<ProductStateType>
    {
        public void Configure(EntityTypeBuilder<ProductStateType> builder)
        {
            builder.ToTable("ProductStateTypes");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
