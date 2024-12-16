using System.Text;
using System.Text.Json;
using MediatR;
using MicroBanking.Domain.Core.Bus;
using MicroBanking.Domain.Core.Commands;
using MicroBanking.Domain.Core.Events;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Rabbit.Infa.Bus;

// ReSharper disable once InconsistentNaming
public sealed class RabbitMQBus(IMediator mediator):IEventBus
{
    private readonly Dictionary<string, List<Type>> _handlers = new();
    private readonly List<Type> _eventTypes= new ();
    
    
    public Task SendCommand<T>(T command) where T : Command
    {
        return mediator.Send(command);
    }

    public void Publish<T>(T @event) where T : Event
    {
        var factory = new ConnectionFactory() {HostName = "localhost"};
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            var eventName = @event.GetType().Name;
            channel.QueueDeclare(eventName, false, false,false, null);
            var message = JsonSerializer.Serialize(@event);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish("",eventName,null,body);
        }
    }

    public void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>
    {
        var eventName = typeof(T).Name;
        var handlerType = typeof(TH);
        
        if(!_eventTypes.Contains(typeof(T)))
            _eventTypes.Add(typeof(T));
        
        if(!_handlers.ContainsKey(eventName))
            _handlers.Add(eventName,new List<Type>());

        if (_handlers[eventName].Any(e => e == handlerType))
            throw new ArgumentException($"Handler type {handlerType.Name} already is registered for {eventName}",nameof(handlerType));
        
        _handlers[eventName].Add(handlerType);

        StartBasicConsume<T>();

    }

    private void StartBasicConsume<T>() where T : Event
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost", 
            DispatchConsumersAsync = true
        };

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        var eventName = typeof(T).Name;
        channel.QueueDeclare(eventName,false,false,false,null);
        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.Received += Consumer_Received;
        channel.BasicConsume(eventName,true,consumer);
    }

    private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
    {
        var eventName = e.RoutingKey;
        var message = Encoding.UTF8.GetString(e.Body.ToArray());

        try
        {
            await ProcessEvent(eventName, message).ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }

    private async Task ProcessEvent(string eventName, string message)
    {
        if (_handlers.ContainsKey(eventName))
        {
            var subscriptions = _handlers[eventName];
            foreach (var sub in subscriptions)
            {
                var handler = Activator.CreateInstance(sub);
                if(handler==null)continue;
                var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);

                var @event = JsonSerializer.Deserialize(message,eventType);

                var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);

                await (Task) concreteType.GetMethod("Handle").Invoke(handler, new object?[] {@event});
            }
        }
    }
}