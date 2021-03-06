namespace Estudos.Viagem.Messages.Events;

public abstract class Event
{
    public string MessageType { get; }
    public Guid CorrelationalId { get; set; }
    public DateTime Timestamp { get; private set; }

    protected Event()
    {
        Timestamp = DateTime.Now;
        MessageType = GetType().Name;
    }
}