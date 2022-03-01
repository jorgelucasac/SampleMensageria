using Estudos.Viagem.Application.Repositories;
using Estudos.Viagem.Messages.Events;
using MassTransit;

namespace Estudos.Viagem.Application.Consumers
{
    public class AtualizarHotelViagemSucessoConsumer : IConsumer<HotelReservadoEvent>
    {
        private readonly IViagemRepository _viagemRepository;

        public AtualizarHotelViagemSucessoConsumer(IViagemRepository viagemRepository)
        {
            _viagemRepository = viagemRepository;
        }

        public async Task Consume(ConsumeContext<HotelReservadoEvent> context)
        {
            var viagem = await _viagemRepository.GetById(context.Message.ViagemId);
            if (viagem == null) return;

            viagem.AtualizarValorComHotel(context.Message.ValorDiaria);
            viagem.ConfirmarReservaHotel();
            await _viagemRepository.Update(viagem);
            //TODO: Inserir dados do hotel no banco
        }
    }

    public class AtualizarHotelViagemFalhaConsumer : IConsumer<HotelReservaFalhou>
    {
        private readonly IViagemRepository _viagemRepository;

        public AtualizarHotelViagemFalhaConsumer(IViagemRepository viagemRepository)
        {
            _viagemRepository = viagemRepository;
        }

        public async Task Consume(ConsumeContext<HotelReservaFalhou> context)
        {
            var viagem = await _viagemRepository.GetById(context.Message.ViagemId);
            if (viagem == null) return;

            if (context.Message.Excessao)
            {
                viagem.CancelarViagem();
                viagem.AddMensagensValidacoes(context.Message.Mensagens);
                await _viagemRepository.Update(viagem);
                return;
            }

            viagem.AddMensagensValidacoes(context.Message.Mensagens);
            await _viagemRepository.Update(viagem);
        }
    }
}