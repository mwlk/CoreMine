using Microsoft.Extensions.DependencyInjection;
using MiVivero.ApplicationBusiness.Interfaces;
using MiVivero.Entities;

namespace MiVivero.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Product>, ProductsRepository>();

            return services;
        }
    }
}
