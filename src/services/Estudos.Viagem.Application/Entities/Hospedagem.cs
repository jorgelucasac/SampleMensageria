namespace Estudos.Viagem.Application.Entities
{
    public class Hospedagem : BaseEntity
    {
        public Hospedagem() { }

        public Hospedagem(Guid hotelId, string nomeHotel, decimal precoDiaria)
        {
            HotelId = hotelId;
            NomeHotel = nomeHotel;
            PrecoDiaria = precoDiaria;
        }

        public Guid HotelId { get; private set; }
        public string NomeHotel { get; private set; }
        public decimal PrecoDiaria { get; private set; }

        //TODO: Validar dados
    }
}
