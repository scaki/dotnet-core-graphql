using Helbiz.Application.Interfaces.Repositories;
using Helbiz.Domain.Entities;
using Helbiz.Infrastructure.Context;
using Helbiz.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Helbiz.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString("Default"), m => { m.EnableRetryOnFailure(); }));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            var serviceProvide = app.ApplicationServices;
            using var serviceScope = serviceProvide.CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            InitializeUser(context);
            return app;
        }

        private static void InitializeUser(ApplicationDbContext context)
        {
            var initialUser = new User()
            {
                Firstname = "Admin",
                Lastname = "User",
                Email = "admin@user.com",
                Username = "admin",
                Password = BCrypt.Net.BCrypt.HashPassword("admin")
            };
            context.Users.Add(initialUser);
            context.SaveChanges();
        }
    }
}