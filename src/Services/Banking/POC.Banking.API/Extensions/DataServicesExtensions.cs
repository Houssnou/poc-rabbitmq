using POC.Banking.Core.Interfaces.Repositories;
using POC.Banking.Core.Interfaces;
using POC.Banking.Infrastructure.Data.Repositories;
using POC.Banking.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using POC.Banking.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace POC.Banking.API.Extensions
{
    public static class DataServicesExtensions
    {
        public static IServiceCollection AddDbContextServices(this IServiceCollection services, ConfigurationManager configManager)
        {
            services.AddDbContext<BankingDbContext>(opt => opt.UseSqlServer(configManager.GetConnectionString("Banking")));

            return services;
        }

        public static async Task<IApplicationBuilder> UseDbContextServices(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                var context = services.GetRequiredService<BankingDbContext>();
                await context.Database.MigrateAsync();
                await BankingDbContextSeed.SeedAsync(context, loggerFactory);

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occured during migration");
            }

            return app;
        }

    }
}
