using Banking.Domain.Communication.Commands;
using Banking.Domain.Communication.Events;
using MediatR;
using MicroBanking.Domain.Core.Bus;

namespace Banking.Domain.Communication.CommandHandlers;

public class TransferCommandHandler(IEventBus eventBus):IRequestHandler<CreateTransferCommand,bool>
{
    public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
    {
        //eventBus.SendCommand();
        eventBus.Publish(new TransferCreatedEvent(request.From,request.To,request.Amount));
        return Task.FromResult(true);
    }
}