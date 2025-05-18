using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMine.Data.Configurations
{
    public class MachineConfiguration : IEntityTypeConfiguration<Machine>
    {
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            builder.ToTable("Machines");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Id);

            builder.Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.Description)
                .HasMaxLength(200);

            builder.Property(p => p.AcquisitionDate)
                .IsRequired();

            builder.Property(p => p.IsActive)
                .HasDefaultValue(true);
        }
    }
}
