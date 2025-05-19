using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMine.Data.Configurations
{
    public class RepairConfiguration : IEntityTypeConfiguration<Repair>
    {
        public void Configure(EntityTypeBuilder<Repair> builder)
        {
            builder.ToTable("Repairs");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Id);

            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Observations).HasMaxLength(1000);

            builder.HasOne(p => p.Machine)
                .WithMany(p => p.Repairs)
                .HasForeignKey(p => p.MachineId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
