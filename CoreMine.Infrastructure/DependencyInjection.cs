using Microsoft.Extensions.DependencyInjection;
using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.Entities;
using CoreMine.Infraestructure.Repositories.ReadOnly;
using CoreMine.Infrastructure.Repositories;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.Infraestructure.Repositories;
using CoreMine.Infraestructure;

namespace CoreMine.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IRepository<Product>, ProductsRepository>();
            services.AddScoped<IReadOnlyProductsRepository, ReadOnlyProductsRepository>();

            services.AddScoped<IProductCategoriesRepository, ProductCategoriesRepository>();
            services.AddScoped<IRepository<ProductCategory>, ProductCategoriesRepository>();
            services.AddScoped<IReadOnlyCategoriesRepository, ReadOnlyCategoriesRepository>();

            services.AddScoped<ISuppliersRepository, SuppliersRepository>();
            services.AddScoped<IRepository<Supplier>, SuppliersRepository>();
            services.AddScoped<IReadOnlySuppliersRepository, ReadOnlySuppliersRepository>();

            services.AddScoped<IReadOnlyProductStateTypesRepository, ReadOnlyProductStateTypesRepository>();
            services.AddScoped<IReadOnlyUnitOfMeasuresRepository, ReadOnlyUnitOfMeasuresRepository>();
            services.AddScoped<IReadOnlyMachinesRepository, ReadOnlyMachinesRepository>();
            services.AddScoped<IReadOnlyLocationsRepository, ReadOnlyLocationsRepository>();

            services.AddScoped<IMachinesRepository, MachinesRepository>();

            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IRepairsRepository, RepairsRepository>();
            services.AddScoped<IReadOnlyRepairsRepository, ReadOnlyRepairsRepository>();

            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IReadOnlyStockRepository, ReadOnlyStockRepository>();

            services.AddScoped<IReadOnlyStockMovementTypesRepository, ReadOnlyStockMovementTypesRepository>();
            services.AddScoped<IStockMovementsRepository, StockMovementsRepository>();

            services.AddScoped<IReadOnlyStockLevelsRepository, ReadOnlyStockLevelsRepository>();

            return services;
        }
    }
}
