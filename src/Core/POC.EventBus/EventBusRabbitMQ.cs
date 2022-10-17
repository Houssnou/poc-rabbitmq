
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using POC.Core.Events;

namespace POC.EventBus
{
    public sealed class EventBusRabbitMQ : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly List<Type> _eventTypes;

        public EventBusRabbitMQ(IMediator mediator, IServiceScopeFactory serviceScopeFactory)
        {
            _mediator = mediator;
            _serviceScopeFactory = serviceScopeFactory;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public void Publish<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "rabbitmq",
                Password = "rabbitmq2021!"
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            var eventName = @event.GetType().Name;

            channel.QueueDeclare(eventName, false, false, false, null);

            var body = JsonSerializer.SerializeToUtf8Bytes(@event, @event.GetType(), new JsonSerializerOptions
            {
                WriteIndented = true
            });

            channel.BasicPublish("", eventName, null, body);
            Console.WriteLine("Sent message: {0} ...", eventName);
        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlerType = typeof(TH);

            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            if (!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new List<Type>());
            }
            if (_handlers[eventName].Any(x => x.GetType() == handlerType))
            {
                throw new ArgumentException($"Handler Type {handlerType.Name} exits already for '{eventName}'", nameof(handlerType));
            }

            _handlers[eventName].Add(handlerType);

            ProcessMessage<T>();
        }

        private void ProcessMessage<T>() where T : Event
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "rabbitmq",
                Password = "rabbitmq2021!",
                DispatchConsumersAsync = true
            };

             var connection = factory.CreateConnection();
             var channel = connection.CreateModel();

            var eventName = typeof(T).Name;

            channel.QueueDeclare(queue: eventName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.Received += Consumer_Received;

            channel.BasicConsume(eventName, false, consumer);
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs args)
        {
            var eventName = args.RoutingKey;
            var body = Encoding.UTF8.GetString(args.Body.ToArray());

            try
            {
                await ProcessEvent(eventName, body).ConfigureAwait(false);
                Console.WriteLine("Received message: {0}", eventName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to process received message: {0}", eventName);
                throw;
            }
        }

        private async Task ProcessEvent(string eventName, string body)
        {
            if (_handlers.ContainsKey(eventName))
            {
                using var scope = _serviceScopeFactory.CreateScope();

                var subcriptions = _handlers[eventName];

                foreach (var sub in subcriptions)
                {
                    var handler = scope.ServiceProvider.GetService(sub);

                    if (handler == null) continue;

                    var eventType = _eventTypes.SingleOrDefault(x => x.Name == eventName);

                    var @event = JsonSerializer.Deserialize(body, eventType);
                    var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);

                    await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });

                }
            }
        }
    }
}