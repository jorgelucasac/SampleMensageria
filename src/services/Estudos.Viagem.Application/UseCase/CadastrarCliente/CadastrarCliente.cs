using Estudos.Viagem.Domain.Repositories;

namespace Estudos.Viagem.Application.UseCase.CadastrarCliente
{
    public class CadastrarCliente : ICadastrarCliente
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
                output.Message = "Cliente cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                output.Message = "Falha ao cadastrar o cliente";
                output.AddErro(ex.Message);
            }
            return output;
        }
    }
}