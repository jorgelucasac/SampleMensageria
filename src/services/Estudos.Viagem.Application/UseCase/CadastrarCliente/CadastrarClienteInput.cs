using Estudos.Viagem.Application.Entities;
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
    }
}