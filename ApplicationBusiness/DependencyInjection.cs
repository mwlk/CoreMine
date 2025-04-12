using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MiVivero.ApplicationBusiness
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationBusiness(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
