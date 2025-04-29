using Microsoft.Extensions.DependencyInjection;
using CoreMine.ApplicationBusiness.Mappings;
using System.Reflection;

namespace CoreMine.ApplicationBusiness
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
