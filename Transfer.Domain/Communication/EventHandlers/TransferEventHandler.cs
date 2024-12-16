using MicroBanking.Domain.Core.Bus;
using Transfer.Domain.Communication.Events;

namespace Transfer.Domain.Communication.EventHandlers;

public class TransferEventHandler:IEventHandler<TransferCreatedEvent>
{
    public TransferEventHandler() { }
    public Task Handle(TransferCreatedEvent @event)
    {
        return Task.CompletedTask;
    }
}