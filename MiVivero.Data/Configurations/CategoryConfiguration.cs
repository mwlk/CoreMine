using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiVivero.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiVivero.Data.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

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
