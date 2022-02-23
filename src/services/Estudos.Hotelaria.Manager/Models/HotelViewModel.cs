using Estudos.Hotelaria.Application.Entities;

namespace Estudos.Hotelaria.Manager.Models
{
    public class HotelViewModel
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Cidade { get; set; }

        public TipoAcomodacao TipoAcomodacao { get; set; }

        public decimal ValorDiaria { get; set; }

        public int QuantidadeQuartos { get; set; }

        public int QuantidadeQuartosOcupados { get; set; }
    }
}
