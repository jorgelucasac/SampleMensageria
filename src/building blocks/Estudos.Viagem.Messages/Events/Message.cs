namespace Estudos.Viagem.Messages.Events;

public abstract class Message
{
    public string MessageType { get; }
    public int CorrelationalId { get; set; }

    protected Message()
    {
        MessageType = GetType().Name;
    }
}