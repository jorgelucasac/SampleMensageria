using FluentValidation;
using FluentValidation.Results;

namespace Estudos.Viagem.Domain.ValueObjects
{
    public class Passagem
    {
        public Passagem(string origem,
            string destino,
            DateOnly dataIda,
            DateOnly dataVolta,
            int quantidadeViajantes
        )
        {
            Origem = origem;
            Destino = destino;
            DataIda = dataIda;
            DataVolta = dataVolta;
            QuantidadeViajantes = quantidadeViajantes;
        }

        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateOnly DataIda { get; set; }
        public DateOnly DataVolta { get; set; }
        public int QuantidadeViajantes { get; set; }

        public ValidationResult Validate() => new PassagemValidation().Validate(this);

        internal class PassagemValidation : AbstractValidator<Passagem>
        {
            public PassagemValidation()
            {
                RuleFor(x => x.Origem)
                    .NotEmpty()
                    .WithMessage("Preenchimento obrigatório");

                RuleFor(x => x.Destino)
                    .NotEmpty()
                    .WithMessage("Preenchimento obrigatório");

                RuleFor(x => x.DataIda)
                    .NotEmpty()
                    .WithMessage("Preenchimento obrigatório");

                RuleFor(x => x.DataVolta)
                    .NotEmpty()
                    .WithMessage("Preenchimento obrigatório")
                    .GreaterThan(x => x.DataIda.AddDays(2))
                    .WithMessage(x => $"A data de volta deve ser maior do que {x.DataIda.AddDays(2).ToString("dd/MM/yyyy")}");

                RuleFor(x => x.QuantidadeViajantes)
                    .GreaterThanOrEqualTo(1)
                    .WithMessage("A quantidade de passageiros deve ser maior ou igual a 1");
            }
        }
    }
}