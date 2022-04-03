using Estudos.Viagem.Domain.Repositories;

namespace Estudos.Viagem.Application.UseCase.ObterViagens
{
    internal class ObterViagens : IObterViagens
    {
        private readonly IViagemRepository _viagemRepository;

        public ObterViagens(IViagemRepository viagemRepository)
        {
            _viagemRepository = viagemRepository;
        }

        public async Task<ObterViagensOutput> Handle(ObterViagensInput request, CancellationToken cancellationToken)
        {
            try
            {
                var viagens = await _viagemRepository.GetAll();
                return new ObterViagensOutput(viagens);
            }
            catch (Exception ex)
            {
                return new ObterViagensOutput("Ocorre um erro ao obter as viagens", ex.Message);
            }
        }
    }
}