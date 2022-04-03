using Estudos.Viagem.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Estudos.Viagem.Application.UseCase.CadastrarCliente
{
    public class CadastrarClienteInput : IRequest<CadastrarClienteOutput>
    {
        public CadastrarClienteInput(string nome, string cpf, DateOnly dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateOnly DataNascimento { get; private set; }

        public Cliente ToCliente()
        {
            return new Cliente(Nome, Cpf, DataNascimento);
        }

        internal ValidationResult Validate() => new CriarViagemInputValidation().Validate(this);

        internal class CriarViagemInputValidation : AbstractValidator<CadastrarClienteInput>
        {
            public CriarViagemInputValidation()
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