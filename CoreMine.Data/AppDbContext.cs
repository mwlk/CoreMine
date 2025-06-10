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
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductState> ProductStates { get; set; }
        public DbSet<ProductStateType> ProductStateTypes { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockLevel> StockLevels { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<StockMovementType> StockMovementTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<RepairProduct> RepairProducts { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }

        #region sql views
        public DbSet<RepairWithProductsReadModel> RepairsWithProducts => Set<RepairWithProductsReadModel>();

        public DbSet<ProductsWithFullCategoryInfoReadModel> ProductsWithFullCategoryInfo => Set<ProductsWithFullCategoryInfoReadModel>();

        public DbSet<CategoryWithFullCodeReadModel> Categories => Set<CategoryWithFullCodeReadModel>();
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            #region view's configuration
            modelBuilder.Entity<RepairWithProductsReadModel>()
               .HasNoKey()
               .ToView("vw_RepairsWithProducts");

            modelBuilder.Entity<ProductsWithFullCategoryInfoReadModel>()
                .HasNoKey()
                .ToView("vw_ProductsWithFullCategoryInfo");

            modelBuilder.Entity<CategoryWithFullCodeReadModel>()
                .HasNoKey()
                .ToView("vw_CategoriesWithFullCode");
            #endregion
        }
    }
}
