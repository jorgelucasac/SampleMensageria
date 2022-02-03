using Estudos.Viagem.Application.UseCase.CriarViagem;

namespace Estudos.Viagem.WebApi.Transport;

public class CriarViagemTransport
{
    public int VooId { get; set; }
    public string Destino { get; set; } = string.Empty;
    public string NomeCliente { get; set; } = string.Empty;
    public int? HotelId { get; set; }
    public int? CarroId { get; set; }

    public CriarViagemInput ToViagemInput()
    {
        return new CriarViagemInput(
            VooId,
            Destino,
            NomeCliente,
            HotelId,
            CarroId);
    }
}