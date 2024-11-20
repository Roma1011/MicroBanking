using MediatR;
using MicroBanking.Domain.Communication.Commands;
using MicroBanking.Domain.Communication.Events;
using MicroBanking.Domain.Core.Bus;

namespace MicroBanking.Domain.Communication.CommandHandlers;

public class TransferCommandHandler(IEventBus eventBus):IRequestHandler<CreateTransferCommand,bool>
{
    public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
    {
        //eventBus.SendCommand();
        eventBus.Publish(new TransferCreatedEvent(request.From,request.To,request.Amount));
        return Task.FromResult(true);
    }
}