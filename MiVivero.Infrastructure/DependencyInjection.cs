using Microsoft.Extensions.DependencyInjection;
using MiVivero.Infrastructure.Mappings;

namespace MiVivero.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductProfile).Assembly);

            return services;
        }
    }
}
