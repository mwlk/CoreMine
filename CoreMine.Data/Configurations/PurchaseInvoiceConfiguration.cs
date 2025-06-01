using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMine.Data.Configurations
{
    public class PurchaseInvoiceConfiguration : IEntityTypeConfiguration<PurchaseInvoice>
    {
        public void Configure(EntityTypeBuilder<PurchaseInvoice> builder)
        {
            builder.ToTable("PurchaseInvoices");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Id);

            builder.HasIndex(p => p.InvoiceNumber)
                .IsUnique();

            builder.Property(p => p.InvoiceNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.IngresedAt)
                .IsRequired();

            builder.HasOne(p => p.Supplier)
                .WithMany(q => q.PurchaseInvoices)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PurchaseInvoiceDetails)
                .WithOne(q => q.PurchaseInvoice)
                .HasForeignKey(p => p.PurchaseInvoiceId);
        }
    }
}
