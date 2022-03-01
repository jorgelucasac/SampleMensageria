using FluentValidation;
using FluentValidation.Results;

namespace Estudos.Hotelaria.Application.Entities
{
    public class Hotel : BaseEntity
    {
        public Hotel(string nome, string cidade, TipoAcomodacao tipoAcomodacao, decimal valorDiaria, int quantidadeQuartos, int quantidadeQuartosOcupados = 0)
        {
            Nome = nome;
            Cidade = cidade;
            TipoAcomodacao = tipoAcomodacao;
            ValorDiaria = valorDiaria;
            QuantidadeQuartos = quantidadeQuartos;
            DataCadastro = DateTime.Now;
            QuantidadeQuartosOcupados = quantidadeQuartosOcupados;
        }

        public string Nome { get; private set; }

        public string Cidade { get; private set; }

        public TipoAcomodacao TipoAcomodacao { get; private set; }

        public decimal ValorDiaria { get; private set; }

        public int QuantidadeQuartos { get; private set; }

        public int QuantidadeQuartosOcupados { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public bool AdicionarReserva(int qtdReservas = 0)
        {
            if (qtdReservas == 0)
                QuantidadeQuartosOcupados++;

            else
                QuantidadeQuartosOcupados += qtdReservas;

            return Validate().IsValid;
        }

        public bool RemoverReserva(int qtdReservas = 0)
        {
            if (qtdReservas == 0)
                QuantidadeQuartosOcupados--;

            else
                QuantidadeQuartosOcupados -= qtdReservas;

            return Validate().IsValid;
        }

        public ValidationResult Validate()
        {
            var validation = new HotelValidation().Validate(this);
            return validation;
        }

        public class HotelValidation : AbstractValidator<Hotel>
        {
            public HotelValidation()
            {
                RuleFor(x => x.QuantidadeQuartos)
                    .GreaterThan(0)
                    .WithMessage("A quantidade de quartos deve ser mair que zero");

                RuleFor(x => x.QuantidadeQuartosOcupados)
                  .LessThanOrEqualTo(x => x.QuantidadeQuartos)
                  .WithMessage("Quantidade de quartos insuficientes para realizar a reserva");
            }
        }
    }

    public enum TipoAcomodacao
    {
        Solteiro,
        Casal
    }
}
