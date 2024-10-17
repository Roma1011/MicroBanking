using MediatR;

namespace MicroBanking.Domain.Core.Events;

public abstract class Message:IRequest<bool>
{
    public string MessageType { get; protected set; }

    public Message()
    {
        this.MessageType = GetType().Name;
    }
}