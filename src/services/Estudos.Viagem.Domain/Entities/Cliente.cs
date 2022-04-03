using FluentValidation;
using FluentValidation.Results;

namespace Estudos.Viagem.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(string nome, string cpf, DateOnly dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateOnly DataNascimento { get; private set; }

        internal ValidationResult Validate() => new ClienteValidation().Validate(this);

        internal class ClienteValidation : AbstractValidator<Cliente>
        {
            public ClienteValidation()
            {
                RuleFor(x => x.Nome)
                    .NotEmpty()
                    .WithMessage("Preenchimento obrigatório");

                RuleFor(x => x.Cpf)
                    .NotEmpty()
                    .WithMessage("Preenchimento obrigatório")
                    .Length(11)
                    .WithMessage("O CPF deve ter 11 caracteres");

                RuleFor(x => x.DataNascimento)
                    .NotEmpty()
                    .WithMessage("Preenchimento obrigatório");
            }
        }
    }
}