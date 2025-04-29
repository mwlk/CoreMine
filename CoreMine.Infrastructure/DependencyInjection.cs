using Microsoft.Extensions.DependencyInjection;
using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.Entities;
using CoreMine.Infraestructure.Repositories.ReadOnly;
using CoreMine.Infrastructure.Repositories;

namespace CoreMine.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IRepository<Product>, ProductsRepository>();
            services.AddTransient<IReadOnlyProductsRepository, ReadOnlyProductsRepository>();

            services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            services.AddTransient<IRepository<Category>, CategoriesRepository>();
            services.AddTransient<IReadOnlyCategoriesRepository, ReadOnlyCategoriesRepository>();

            return services;
        }
    }
}
