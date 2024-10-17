using MicroBanking.Domain.Core.Events;

namespace MicroBanking.Domain.Core.Commands;

public abstract class Command : Message
{
    public DateTime TimeStamp { get; protected set; }

    protected Command()
    {
        this.TimeStamp = DateTime.Now;
    }
}