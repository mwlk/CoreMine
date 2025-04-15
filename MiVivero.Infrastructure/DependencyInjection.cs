using Microsoft.Extensions.DependencyInjection;
using MiVivero.ApplicationBusiness.Interfaces;
using MiVivero.Entities;
using MiVivero.Infrastructure.Repositories;

namespace MiVivero.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IRepository<Product>, ProductsRepository>();

            return services;
        }
    }
}
