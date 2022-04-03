using FluentValidation.Results;
using MediatR;

namespace Estudos.Viagem.Application.UseCase.AtualizarViagemComHotel
{
    public class AtualizarViagemComHotelInput : IRequest<AtualizarViagemComHotelOutput>
    {
        public AtualizarViagemComHotelInput(Guid viagemId, Guid? hotelId, string? nomeHotel, decimal? valorDiaria)
        {
            ViagemId = viagemId;
            HotelId = hotelId;
            NomeHotel = nomeHotel;
            ValorDiaria = valorDiaria;
            MensagensValidacao = new List<ValidationFailure>();
        }

        public AtualizarViagemComHotelInput(Guid viagemId, IList<ValidationFailure> mensagensValidacao)
        {
            ViagemId = viagemId;
            MensagensValidacao = mensagensValidacao;
        }

        public Guid ViagemId { get; private set; }
        public Guid? HotelId { get; private set; }
        public string? NomeHotel { get; private set; }
        public decimal? ValorDiaria { get; private set; }
        public IList<ValidationFailure> MensagensValidacao { get; private set; }
    }
}
