using POC.Transfer.Core.Interfaces;
using POC.Transfer.Core.Interfaces.Repositories;
using POC.Transfer.Infrastructure.Data.Repositories;
using POC.Transfer.Infrastructure.Services;

namespace POC.Transfer.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<ITransferService, TransferService>();
            // services.AddTransient<IRequestHandler<NewTransferCommand, bool>, TransferCommandHandler>();

            return services;
        }
    }
}
