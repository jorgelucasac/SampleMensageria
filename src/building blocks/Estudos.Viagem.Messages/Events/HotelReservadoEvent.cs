using FluentValidation.Results;

namespace Estudos.Viagem.Messages.Events
{
    public class HotelReservadoEvent : Event
    {
        public HotelReservadoEvent(Guid viagemId, Guid hotelId, string nomeHotel, decimal valorDiaria)
        {
            CorrelationalId = viagemId;
            ViagemId = viagemId;
            HotelId = hotelId;
            NomeHotel = nomeHotel;
            ValorDiaria = valorDiaria;
        }

        public Guid ViagemId { get; private set; }
        public Guid HotelId { get; private set; }
        public string NomeHotel { get; private set; }
        public decimal ValorDiaria { get; private set; }
    }

    public class HotelReservaFalhou : Event
    {
        protected HotelReservaFalhou() { }

        public HotelReservaFalhou(Guid viagemId, IList<ValidationFailure> mensagens)
        {
            CorrelationalId = viagemId;
            Mensagens = mensagens;
        }

        public HotelReservaFalhou(Guid viagemId, string propertyName, string errorMessage)
        {
            CorrelationalId = viagemId;
            Mensagens = new List<ValidationFailure> { new ValidationFailure(propertyName, errorMessage) };
        }

        public IList<ValidationFailure> Mensagens { get; private set; }
    }
}