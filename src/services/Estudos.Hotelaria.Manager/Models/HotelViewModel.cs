using Estudos.Hotelaria.Application.Entities;
using FluentValidation;
using FluentValidation.Results;

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

        public ValidationResult Validate()
        {
            var validation = new HotelViewModelValidation().Validate(this);
            return validation;
        }

        public class HotelViewModelValidation : AbstractValidator<HotelViewModel>
        {
            public HotelViewModelValidation()
            {
                RuleFor(x => x.QuantidadeQuartos)
                    .GreaterThan(0)
                    .WithMessage("A quantidade de quartos deve ser mair que zero");

                RuleFor(x => x.QuantidadeQuartosOcupados)
                  .GreaterThan(-1)
                  .WithMessage("A quantidade de quartos ocupados deve ser mair que -1");

                RuleFor(x => x.QuantidadeQuartosOcupados)
                .LessThanOrEqualTo(x => x.QuantidadeQuartos)
                .WithMessage("A quantidade de quartos ocupados deve ser menor ou igual a quantidade de quartos");
            }
        }
    }
}
