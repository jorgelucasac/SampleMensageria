using Estudos.Viagem.Domain.Repositories;

namespace Estudos.Viagem.Application.UseCase.AtualizarViagemComHotel
{
    internal class AtualizarViagemComHotel : IAtualizarViagemComHotel
    {
        private readonly IViagemRepository _viagemRepository;

        public AtualizarViagemComHotel(IViagemRepository viagemRepository)
        {
            _viagemRepository = viagemRepository;
        }

        public async Task<AtualizarViagemComHotelOutput> Handle(AtualizarViagemComHotelInput request, CancellationToken cancellationToken)
        {
            try
            {
                var viagem = await _viagemRepository.GetById(request.ViagemId);
                if (viagem == null)
                    return new AtualizarViagemComHotelOutput("Viagem não encontrada");

                if (request.MensagensValidacao.Any())
                {
                    viagem.AddMensagensValidacoes(request.MensagensValidacao);
                    await _viagemRepository.Update(viagem);
                    return new AtualizarViagemComHotelOutput("Ocorreu um erro ao reservar o hotel", request.MensagensValidacao);
                }

                viagem.AddHospedagem(request.HotelId.Value, request.NomeHotel, request.ValorDiaria.Value);
                var hospedagem = viagem.Hospedagem.Validate();
                if (!hospedagem.IsValid)
                    return new AtualizarViagemComHotelOutput("Os dados de hospedagem são inválidos", hospedagem.Errors);

                viagem.AtualizarValorComHotel(request.ValorDiaria.Value);
                viagem.ConfirmarReservaHotel();
                await _viagemRepository.Update(viagem);

                return new AtualizarViagemComHotelOutput();
            }
            catch (Exception ex)
            {
                return new AtualizarViagemComHotelOutput("Ocorreu um erro ao atualizar a viagem", ex.Message);
            }
        }
    }
}
