using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.Mappings;
using CoreMine.ApplicationBusiness.UseCases.Categories.Commands;
using CoreMine.ApplicationBusiness.UseCases.Categories.Handlers;
using CoreMine.ApplicationBusiness.UseCases.Categories.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CoreMine.ApplicationBusiness
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationBusiness(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductProfile).Assembly);

            Register(services, typeof(ICommandHandler<,>));
            Register(services, typeof(IQueryHandler<,>));

            return services;
        }

        private static void Register(IServiceCollection services, Type openGenericHandlerType)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var handlers = assembly
                .GetTypes()
                .Where(p => !p.IsAbstract && !p.IsInterface)
                .SelectMany(q => q.GetInterfaces()
                                .Where(r => r.IsGenericType && r.GetGenericTypeDefinition() == openGenericHandlerType)
                                .Select(s => new { Interface = s, Implementation = q }))
                .ToList();

            foreach (var handler in handlers)
            {
                services.AddScoped(handler.Interface, handler.Implementation);
            }
        }
    }
}
