namespace MicroBanking.Domain.Core.Events;

public abstract class Event
{
    public DateTime Timestamp { get; protected set; }

    protected Event()
    {
        this.Timestamp=DateTime.Now;
    }
}