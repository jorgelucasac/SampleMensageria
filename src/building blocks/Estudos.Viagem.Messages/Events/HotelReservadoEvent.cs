namespace Estudos.Viagem.Messages.Events
{
    public class HotelReservadoEvent : Event
    {
        public HotelReservadoEvent(Guid viagemId, decimal valorDiaria)
        {
            CorrelationalId = viagemId;
            ViagemId = viagemId;
            ValorDiaria = valorDiaria;
            CorrelationalId = viagemId;
        }

        public Guid ViagemId { get; private set; }
        public decimal ValorDiaria { get; private set; }
    }

    public class HotelReservaFalhou : Event
    {

        public HotelReservaFalhou(Guid viagemId, IList<string> mensagens, bool excessao = false)
        {
            CorrelationalId = viagemId;
            ViagemId = viagemId;
            Mensagens = mensagens ?? new List<string>();
            Excessao = excessao;
        }

        public Guid ViagemId { get; private set; }
        public IList<string> Mensagens { get; private set; }
        //se é excessão, então houve uma falha, caso contrário está apenas validando
        public bool Excessao { get; private set; }
    }
}