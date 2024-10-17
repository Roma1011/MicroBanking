using MicroBanking.Domain.Core.Events;

namespace MicroBanking.Domain.Core.Bus;

public interface IEventHandler<in TEvent> : IEventHandler
where TEvent:Event
{
    Task Handle(TEvent @event);
}

public interface IEventHandler;