using Microsoft.Extensions.DependencyInjection;
using MiVivero.ApplicationBusiness.Mappings;
using System.Reflection;

namespace MiVivero.ApplicationBusiness
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationBusiness(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductProfile).Assembly);

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
