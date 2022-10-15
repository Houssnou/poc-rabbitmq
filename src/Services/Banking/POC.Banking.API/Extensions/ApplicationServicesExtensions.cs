using Microsoft.EntityFrameworkCore;
using POC.Banking.Core.Interfaces;
using POC.Banking.Core.Interfaces.Repositories;
using POC.Banking.Infrastructure.Data;
using POC.Banking.Infrastructure.Data.Repositories;
using POC.Banking.Infrastructure.Services;

namespace POC.Banking.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();

            return services;
        }
    }
}
