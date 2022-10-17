using POC.Core.Bus;
using POC.Transfer.Core.EventHandlers;
using POC.Transfer.Core.Events;
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

            services.AddTransient<TransferCreatedEventHandler>();

            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferCreatedEventHandler>();

            return services;
        }

        public static IApplicationBuilder UseEventBusSubscription(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<TransferCreatedEvent, TransferCreatedEventHandler>();

            return app;
        }
    }
}
