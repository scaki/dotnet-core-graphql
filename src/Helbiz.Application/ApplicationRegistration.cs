using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Helbiz.Application.Helpers;
using Helbiz.Application.Interfaces.Helpers;


namespace Helbiz.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);
            services.AddScoped<IJwtHelper, JwtHelper>();
            return services;
        }
    }
}