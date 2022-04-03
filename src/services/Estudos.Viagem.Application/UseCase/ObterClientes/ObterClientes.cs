using Estudos.Viagem.Domain.Repositories;

namespace Estudos.Viagem.Application.UseCase.ObterClientes
{
    public class ObterClientes : IObterClientes
    {
        private readonly IClienteRepository _clienteRepository;
        public ObterClientes(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ObterClientesOutput> Handle(ObterClientesInput request, CancellationToken cancellationToken)
        {
            try
            {
                var clientes = await _clienteRepository.GetAll();
                return new ObterClientesOutput(clientes);
            }
            catch (Exception ex)
            {
                return new ObterClientesOutput("Ocorre um erro ao obter os clientes", ex.Message);
            }
        }
    }
}