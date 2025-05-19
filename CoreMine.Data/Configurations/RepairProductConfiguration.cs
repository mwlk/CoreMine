using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMine.Data.Configurations
{
    public class RepairProductConfiguration : IEntityTypeConfiguration<RepairProduct>
    {
        public void Configure(EntityTypeBuilder<RepairProduct> builder)
        {
            builder.ToTable("RepairProducts");

            builder.HasKey(rp => new { rp.RepairId, rp.ProductId });

            builder.Property(rp => rp.QuantityUsed)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(rp => rp.Repair)
                .WithMany(r => r.RepairProducts)
                .HasForeignKey(rp => rp.RepairId);

            builder.HasOne(rp => rp.Product)
                .WithMany()
                .HasForeignKey(rp => rp.ProductId);
        }
    }

}
