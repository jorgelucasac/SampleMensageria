using FluentValidation;
using FluentValidation.Results;

namespace Estudos.Viagem.Domain.ValueObjects
{
    public class Carro
    {
        public Carro(Guid carroId, string modelo, string categoria, decimal valorDiaria)
        {
            CarroId = carroId;
            Modelo = modelo;
            Categoria = categoria;
            ValorDiaria = valorDiaria;
        }

        public Guid CarroId { get; private set; }
        public string Modelo { get; private set; }
        public string Categoria { get; private set; }
        public decimal ValorDiaria { get; private set; }

        public ValidationResult Validate() => new CarroValidation().Validate(this);

        internal class CarroValidation : AbstractValidator<Carro>
        {
            public CarroValidation()
            {
                RuleFor(x => x.CarroId)
                    .NotEmpty()
                    .WithMessage("Preenchimento obrigatório");

                RuleFor(x => x.Modelo)
                    .NotEmpty()
                    .WithMessage("Preenchimento obrigatório");

                RuleFor(x => x.Categoria)
                    .NotEmpty()
                    .WithMessage("Preenchimento obrigatório");

                RuleFor(x => x.ValorDiaria)
                    .GreaterThan(0)
                    .WithMessage("O valor deve ser maior que 0");
            }
        }
    }
}
