using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMine.Data.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Surname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Contact)
                .HasMaxLength(100);

            builder.Property(p => p.Phone)
                .HasMaxLength(20);

            builder.Property(p => p.CreatedAt)
                .IsRequired();
        }
    }
}
