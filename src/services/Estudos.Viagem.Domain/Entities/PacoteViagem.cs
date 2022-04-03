using Estudos.Viagem.Domain.Models;
using Estudos.Viagem.Domain.ValueObjects;
using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using static Estudos.Viagem.Domain.ValueObjects.Carro;
using static Estudos.Viagem.Domain.ValueObjects.Hospedagem;
using static Estudos.Viagem.Domain.ValueObjects.Passagem;

namespace Estudos.Viagem.Domain.Entities
{
    public partial class PacoteViagem : BaseEntity
    {
        protected PacoteViagem() { }

        public PacoteViagem(Passagem passagem, Guid clienteId)
        {
            Passagem = passagem;
            ClienteId = clienteId;
            Status = StatusViagem.EmAnalise;
            DataCadastro = DateTime.Now;
            DataUltimaAtualizacao = DateTime.Now;
            CalcularValorViagem();
        }

        public Passagem Passagem { get; private set; }
        public Hospedagem? Hospedagem { get; private set; }
        public Carro? Carro { get; set; }
        public Guid ClienteId { get; private set; }
        public decimal Total { get; private set; }
        public StatusViagem Status { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataUltimaAtualizacao { get; private set; }
        public string? MensagensValidacoes { get; private set; }
        public bool ReservarHotel { get; private set; }
        public bool AlugarCarro { get; private set; }

        public virtual Cliente Cliente { get; set; }

        public void AgendarViagem()
        {
            Status = StatusViagem.Agendada;
            DataUltimaAtualizacao = DateTime.Now;
        }

        public void ConfirmarReservaHotel()
        {
            Status = StatusViagem.HotelReservado;
            DataUltimaAtualizacao = DateTime.Now;
        }

        public void ConfirmarReservaCarro()
        {
            Status = StatusViagem.CarroReservado;
            DataUltimaAtualizacao = DateTime.Now;
        }

        public void ConfirmarViagem()
        {
            Status = StatusViagem.Realizada;
            DataUltimaAtualizacao = DateTime.Now;
        }

        public void CancelarViagem()
        {
            Status = StatusViagem.Cancelada;
            DataUltimaAtualizacao = DateTime.Now;
        }

        private void CalcularValorViagem()
        {
            if (Passagem == null) return;

            var diarias = GetQuantidadeDiarias();
            Total = (diarias <= 0 ? 1 : diarias) * 500 * Passagem.QuantidadeViajantes;
        }

        public void AddHospedagem(Guid hotelId, string nomeHotel, decimal precoDiaria)
        {
            Hospedagem = new Hospedagem(hotelId, nomeHotel, precoDiaria);
        }

        public void AtualizarValorComHotel(decimal valorDiaria)
        {
            if (Hospedagem == null) return;

            var diarias = GetQuantidadeDiarias();
            Total += (diarias <= 0 ? 1 : diarias) * valorDiaria;
        }

        public void AtualizarValorComCarro(decimal valorDiaria)
        {
            if (Carro == null) return;

            var diarias = GetQuantidadeDiarias();
            Total += (diarias <= 0 ? 1 : diarias) * valorDiaria;
        }

        private int GetQuantidadeDiarias()
        {
            var dataIda = Passagem.DataIda.ToDateTime(TimeOnly.Parse("00:00"));
            var dataVolta = Passagem.DataVolta.ToDateTime(TimeOnly.Parse("00:00"));
            var diarias = (dataVolta - dataIda).Days;
            return diarias;
        }

        public void AddMensagensValidacoes(IList<ValidationFailure> mensagens)
        {
            var msg = JsonConvert.SerializeObject(mensagens);
            MensagensValidacoes = msg;
        }

        public void SetReservarHotel() => ReservarHotel = true;

        public void SetAlugarCarro() => AlugarCarro = true;

        public ValidationResult Validate() => new PacoteViagemValidation().Validate(this);

        internal class PacoteViagemValidation : AbstractValidator<PacoteViagem>
        {
            public PacoteViagemValidation()
            {
                RuleFor(x => x.Passagem).SetValidator(new PassagemValidation());
                RuleFor(x => x.Carro).SetValidator(new CarroValidation()).When(x => x.Carro != null);
                RuleFor(x => x.Hospedagem).SetValidator(new HospedagemValidation()).When(x => x.Hospedagem != null);

                RuleFor(x => x.ClienteId)
                    .NotEmpty()
                    .WithMessage("Informe os dados do cliente");

                RuleFor(x => x.Total)
                    .GreaterThan(0)
                    .WithMessage("O valor deve ser maior que {PropertyValue}");
            }
        }
    }
}