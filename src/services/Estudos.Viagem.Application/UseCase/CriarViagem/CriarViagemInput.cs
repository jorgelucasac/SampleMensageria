using Estudos.Viagem.Domain.Entities;
using Estudos.Viagem.Domain.ValueObjects;
using Estudos.Viagem.Messages.Events;
using FluentValidation;
using FluentValidation.Results;
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

    internal ValidationResult Validate() => new CriarViagemInputValidation().Validate(this);

    internal ViagemCriadaEvent ToEvent(Guid idViagem)
    {
        return new ViagemCriadaEvent
        {
            CorrelationalId = idViagem,
            Destino = Destino,
            DataIda = DataIda.ToDateTime(TimeOnly.MinValue),
            DataVolta = DataVolta.ToDateTime(TimeOnly.MinValue),
            QuantidadeViajantes = QuantidadeViajantes,
            HospedagemId = HospedagemId,
            CarroId = CarroId
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
        return new PacoteViagem(passagem, ClienteId);
    }

    internal class CriarViagemInputValidation : AbstractValidator<CriarViagemInput>
    {
        public CriarViagemInputValidation()
        {
            RuleFor(x => x.Origem)
                .NotEmpty()
                .WithMessage("Preenchimento obrigatório");

            RuleFor(x => x.Destino)
                .NotEmpty()
                .WithMessage("Preenchimento obrigatório");

            RuleFor(x => x.DataIda)
                .NotEmpty()
                .WithMessage("Preenchimento obrigatório");

            RuleFor(x => x.DataVolta)
                .NotEmpty()
                .WithMessage("Preenchimento obrigatório")
                .GreaterThan(x => x.DataVolta.AddDays(2))
                .WithMessage(x => $"A data de volta deve ser maior do que { x.DataVolta.AddDays(2).ToString("dd/MM/yyyy")}");

            RuleFor(x => x.QuantidadeViajantes)
                .GreaterThanOrEqualTo(1)
                .WithMessage("A quantidade de passageiros deve ser maior ou igual a 1");

            RuleFor(x => x.ClienteId)
                .NotEmpty()
                .WithMessage("Informe os dados do cliente");
        }
    }
}