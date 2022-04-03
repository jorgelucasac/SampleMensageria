using MediatR;

namespace Estudos.Viagem.Application.UseCase.CadastrarCliente
{
    public interface ICadastrarCliente : IRequestHandler<CadastrarClienteInput, CadastrarClienteOutput>
    {
    }
}