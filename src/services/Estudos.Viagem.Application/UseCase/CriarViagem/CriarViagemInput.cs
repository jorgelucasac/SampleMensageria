using Estudos.Viagem.Messages.Events;
using MediatR;

namespace Estudos.Viagem.Application.UseCase.CriarViagem;

public class CriarViagemInput : IRequest<CriarViagemOutput>
{
    public CriarViagemInput(int vooId, string destino, string nomeCliente, int? hotelId = default, int? carroId = default)
    {
        VooId = vooId;
        Destino = destino;
        NomeCliente = nomeCliente;
        HotelId = hotelId;
        CarroId = carroId;
    }

    public int VooId { get; }
    public string Destino { get; }
    public string NomeCliente { get; }
    public int? HotelId { get; }
    public int? CarroId { get; }

    internal ViagemCriadaEvent ToEvent()
    {
        return new ViagemCriadaEvent
        {
            CorrelationalId = VooId
        };
    }
}