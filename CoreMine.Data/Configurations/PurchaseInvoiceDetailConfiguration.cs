using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMine.Data.Configurations
{
    public class PurchaseInvoiceDetailConfiguration : IEntityTypeConfiguration<PurchaseInvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<PurchaseInvoiceDetail> builder)
        {
            builder.ToTable("PurchaseInvoiceDetails");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Id);

            builder.Property(p => p.Quantity)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Product)
                .WithMany(q => q.PurchaseInvoiceDetails)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.PurchaseInvoice)
                .WithMany(q => q.PurchaseInvoiceDetails)
                .HasForeignKey(p => p.PurchaseInvoiceId);
        }
    }
}
