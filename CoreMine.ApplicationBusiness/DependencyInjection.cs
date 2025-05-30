﻿using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CoreMine.ApplicationBusiness
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationBusiness(this IServiceCollection services)
        {
            services.AddScoped<TokenService>();
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
