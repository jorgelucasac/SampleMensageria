using Estudos.Viagem.Application.Entities;
using Estudos.Viagem.Application.ValueObjects;
using Estudos.Viagem.Messages.Events;
using MediatR;

namespace Estudos.Viagem.Application.UseCase.CriarViagem;

public class CriarViagemInput : IRequest<CriarViagemOutput>
{
    public CriarViagemInput(string origem,
        string destino,
        DateOnly dataIda,
        DateOnly dataVolta,
        int quantidadeViajantes,
        Guid clienteId,
        Guid? hospedagemId = null,
        Guid? carroId = null)
    {
        Origem = origem;
        Destino = destino;
        DataIda = dataIda;
        DataVolta = dataVolta;
        QuantidadeViajantes = quantidadeViajantes;
        ClienteId = clienteId;
        HospedagemId = hospedagemId;
        CarroId = carroId;
    }

    public string Origem { get; set; }
    public string Destino { get; set; }
    public DateOnly DataIda { get; set; }
    public DateOnly DataVolta { get; set; }
    public int QuantidadeViajantes { get; set; }
    public Guid ClienteId { get; set; }
    public Guid? HospedagemId { get; set; }
    public Guid? CarroId { get; set; }

    internal ViagemCriadaEvent ToEvent()
    {
        return new ViagemCriadaEvent
        {
            CorrelationalId = ClienteId
        };
    }

    internal PacoteViagem ToViagem()
    {
        var passagem = new Passagem(
            Origem,
            Destino,
            DataIda,
            DataVolta,
            QuantidadeViajantes
        );
        return new PacoteViagem(passagem, ClienteId, HospedagemId, CarroId);
    }
}