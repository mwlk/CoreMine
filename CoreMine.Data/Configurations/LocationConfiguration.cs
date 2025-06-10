using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMine.Data.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .HasMaxLength(100);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(p => p.StockLevels)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
