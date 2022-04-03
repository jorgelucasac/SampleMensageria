using FluentValidation;
using FluentValidation.Results;

namespace Estudos.Viagem.Domain.ValueObjects
{
    public class Hospedagem 
    {
        public Hospedagem(Guid hotelId, string nomeHotel, decimal valorDiaria)
        {
            HotelId = hotelId;
            NomeHotel = nomeHotel;
            ValorDiaria = valorDiaria;
        }

        public Guid HotelId { get; private set; }
        public string NomeHotel { get; private set; }
        public decimal ValorDiaria { get; private set; }

        public ValidationResult Validate() => new HospedagemValidation().Validate(this);

        internal class HospedagemValidation : AbstractValidator<Hospedagem>
        {
            public HospedagemValidation()
            {

                RuleFor(x => x.HotelId)
                    .NotEmpty()
                    .WithMessage("Preenchimento obrigatório");

                RuleFor(x => x.NomeHotel)
                    .NotEmpty()
                    .WithMessage("Preenchimento obrigatório");

                RuleFor(x => x.ValorDiaria)
                  .GreaterThan(0)
                  .WithMessage("O valor deve ser maior que 0");
            }
        }
    }
}
