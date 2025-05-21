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
        //sql view
        public DbSet<RepairWithProductsReadModel> RepairsWithProducts => Set<RepairWithProductsReadModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // sql view for repairs
            modelBuilder.Entity<RepairWithProductsReadModel>()
               .HasNoKey()
               .ToView("vw_RepairsWithProducts");
        }
    }
}
