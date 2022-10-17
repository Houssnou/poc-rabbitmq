using Microsoft.EntityFrameworkCore;
using POC.Transfer.Infrastructure.Data;

namespace POC.Transfer.API.Extensions
{
    public static class DataServicesExtensions
    {
        public static IServiceCollection AddDbContextServices(this IServiceCollection services, ConfigurationManager configManager)
        {
            services.AddDbContext<TransferDbContext>(opt => opt.UseSqlServer(configManager.GetConnectionString("Transfer")));

            return services;
        }
    }
}
