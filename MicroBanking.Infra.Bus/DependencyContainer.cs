using MediatR;
using Banking.Domain.Communication.CommandHandlers;
using Banking.Domain.Communication.Commands;
using MicroBanking.Domain.Core.Bus;
using Microsoft.Extensions.DependencyInjection;
using Rabbit.Infa.Bus;
using Transfer.Domain.Communication.EventHandlers;
using TransferCreatedEvent = Transfer.Domain.Communication.Events.TransferCreatedEvent;

namespace MicroBanking.Infra.Bus;

public class DependencyContainer
{
    public static void RegisterServices(IServiceCollection collection)
    {
        collection.AddTransient<IEventBus, RabbitMQBus>();
        
        collection.AddTransient<IRequestHandler<CreateTransferCommand,bool>, TransferCommandHandler>();
        collection.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

        collection.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(typeof(DependencyContainer).Assembly);
        });
    }
}