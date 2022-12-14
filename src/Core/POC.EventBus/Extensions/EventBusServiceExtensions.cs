using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace POC.EventBus.Extensions
{
    public static class EventBusServiceExtensions
    {
        public static IServiceCollection AddEventBusServices(this IServiceCollection services)
        {
            services.AddSingleton<IEventBus, EventBusRabbitMQ>(
                sp =>
                {
                    var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                    return new EventBusRabbitMQ(sp.GetRequiredService<IMediator>(), scopeFactory);
                });

            services.AddMediatR(Assembly.GetExecutingAssembly());
          //  services.AddTransient<IEventBus, EventBusRabbitMQ>();
            return services;
        }
    }
}
