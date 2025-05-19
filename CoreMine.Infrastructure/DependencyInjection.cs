using Microsoft.Extensions.DependencyInjection;
using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.Entities;
using CoreMine.Infraestructure.Repositories.ReadOnly;
using CoreMine.Infrastructure.Repositories;
using CoreMine.ApplicationBusiness.Interfaces.Shared;

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
            services.AddTransient<IReadOnlyProductStateTypesRepository, ReadOnlyProductStateTypesRepository>();
            services.AddTransient<IReadOnlyUnitOfMeasuresRepository, ReadOnlyUnitOfMeasuresRepository>();

            return services;
        }
    }
}
