using Microsoft.EntityFrameworkCore;
using CoreMine.Data.ReadModels;
using CoreMine.Entities;

namespace CoreMine.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder
                .Entity<ProductWithCategoryReadModel>()
                .HasNoKey()
                .ToView("vw_ProductsWithFullCategoryInfo");

            modelBuilder.Entity<CategoryWithHierarchyReadModel>(e =>
            {
                e.HasNoKey();
                e.ToView("vw_CategoriesWithHierarchy");
            });
        }
    }
}
