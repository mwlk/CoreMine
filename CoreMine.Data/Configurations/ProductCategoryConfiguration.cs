using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreMine.Entities;

namespace CoreMine.Data.Configurations
{
    internal class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");

            builder.HasIndex(p => p.Code)
                .IsUnique();

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Code).IsRequired().HasMaxLength(10);

            builder.HasOne(p => p.Parent)
                .WithMany(q => q.ChildCategories)
                .HasForeignKey(r => r.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
