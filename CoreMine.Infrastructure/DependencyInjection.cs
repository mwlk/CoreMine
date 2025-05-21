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
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IRepository<Product>, ProductsRepository>();
            services.AddTransient<IReadOnlyProductsRepository, ReadOnlyProductsRepository>();

            services.AddTransient<IProductCategoriesRepository, ProductCategoriesRepository>();
            services.AddTransient<IRepository<ProductCategory>, ProductCategoriesRepository>();
            services.AddTransient<IReadOnlyCategoriesRepository, ReadOnlyCategoriesRepository>();

            services.AddTransient<ISuppliersRepository, SuppliersRepository>();
            services.AddTransient<IRepository<Supplier>, SuppliersRepository>();
            services.AddTransient<IReadOnlySuppliersRepository, ReadOnlySuppliersRepository>();

            services.AddTransient<IReadOnlyProductStateTypesRepository, ReadOnlyProductStateTypesRepository>();
            services.AddTransient<IReadOnlyUnitOfMeasuresRepository, ReadOnlyUnitOfMeasuresRepository>();
            services.AddTransient<IReadOnlyStockMovementTypesRepository, ReadOnlyStockMovementTypesRepository>();
            services.AddTransient<IReadOnlyMachinesRepository, ReadOnlyMachinesRepository>();
            services.AddTransient<IReadOnlyLocationsRepository, ReadOnlyLocationsRepository>();

            services.AddTransient<IMachinesRepository, MachinesRepository>();

            services.AddScoped<IDateTimeProvider, DateTimeProvider>();

            services.AddTransient<IReadOnlyRepairsRepository, ReadOnlyRepairsRepository>();

            return services;
        }
    }
}
