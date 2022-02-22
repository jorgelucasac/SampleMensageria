using Estudos.Viagem.Application.UseCase.CriarViagem;
using System.ComponentModel.DataAnnotations;

namespace Estudos.Viagem.WebApi.Transport;

public class CriarViagemRequest
{
    [Required(ErrorMessage = "Preenchimento obrigatório")]
    public string Origem { get; set; }

    [Required(ErrorMessage = "Preenchimento obrigatório")]
    public string Destino { get; set; }

    [Required(ErrorMessage = "Preenchimento obrigatório")]
    public DateTime DataIda { get; set; }

    [Required(ErrorMessage = "Preenchimento obrigatório")]
    public DateTime DataVolta { get; set; }

    [Required(ErrorMessage = "Preenchimento obrigatório")]
    public int QuantidadeViajantes { get; set; }

    [Required(ErrorMessage = "Preenchimento obrigatório")]
    public Guid ClienteId { get; set; }

    public Guid? HospedagemId { get; set; }

    public Guid? CarroId { get; set; }

    public CriarViagemInput ToViagemInput()
    {
        return new CriarViagemInput(
            Origem,
            Destino,
            DateOnly.FromDateTime(DataIda),
            DateOnly.FromDateTime(DataVolta),
            QuantidadeViajantes,
            ClienteId,
            HospedagemId,
            CarroId
        );
    }
}