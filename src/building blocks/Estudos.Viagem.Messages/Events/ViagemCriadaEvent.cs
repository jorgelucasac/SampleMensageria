namespace Estudos.Viagem.Messages.Events;

public class ViagemCriadaEvent : Event
{
    public string Destino { get; set; }
    public DateTime DataIda { get; set; }
    public DateTime DataVolta { get; set; }
    public int QuantidadeViajantes { get; set; }
    public Guid? HospedagemId { get; set; }
    public Guid? CarroId { get; set; }
}