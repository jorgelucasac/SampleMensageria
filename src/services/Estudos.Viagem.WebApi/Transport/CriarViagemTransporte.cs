using Estudos.Viagem.Application.UseCase.CriarViagem;
using System.ComponentModel.DataAnnotations;

namespace Estudos.Viagem.WebApi.Transport;

public class CriarViagemRequest
{
    [Required]
    public int VooId { get; set; }

    public string Destino { get; set; } = string.Empty;

    [Required]
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