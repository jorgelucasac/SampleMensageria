using Estudos.Viagem.Application.Repositories;

namespace Estudos.Viagem.Application.UseCase.CadastrarCliente
{
    public class CadastrarCliente : ICadastrarClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public CadastrarCliente(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<CadastrarClienteOutput> Handle(CadastrarClienteInput request, CancellationToken cancellationToken)
        {
            var output = new CadastrarClienteOutput();
            try
            {
                await _clienteRepository.Save(request.ToCliente());

                output.AddMessage("Cliente cadastrado com sucesso");
            }
            catch (Exception)
            {
                output.AddMessage("Falha ao cadastrar o cliente");
            }
            return output;
        }
    }
}