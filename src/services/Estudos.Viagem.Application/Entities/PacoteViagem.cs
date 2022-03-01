using Estudos.Viagem.Application.ValueObjects;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Estudos.Viagem.Application.Entities
{
    public class PacoteViagem : BaseEntity
    {
        public PacoteViagem() { }

        public PacoteViagem(Passagem passagem, Guid clienteId, Guid? hospedagemId = null, Guid? carroId = null)
        {
            Passagem = passagem;
            ClienteId = clienteId;
            HospedagemId = hospedagemId;
            CarroId = carroId;
            Status = StatusViagem.EmAnalise;
            DataCadastro = DateTime.Now;
            DataUltimaAtualizacao = DateTime.Now;
            CalcularValorViagem();
        }

        public Passagem Passagem { get; private set; }
        public Guid ClienteId { get; private set; }
        public Guid? HospedagemId { get; private set; }
        public Guid? CarroId { get; private set; }
        public decimal Total { get; private set; }
        public StatusViagem Status { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataUltimaAtualizacao { get; private set; }
        public string? MensagensValidacoes { get; private set; }

        public virtual Hospedagem Hospedagem { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Carro Carro { get; set; }

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

        public void AtualizarValorComHotel(decimal valorDiaria)
        {
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

        public void AddMensagensValidacoes(IList<string> mensagens)
        {
            var msg = JsonConvert.SerializeObject(mensagens);
            MensagensValidacoes = msg;
        }

        //TODO: Criar validações

        public enum StatusViagem
        {
            [Description("Em análise")]
            EmAnalise = 1,
            Agendada = 2,
            [Description("Hotel Reservado")]
            HotelReservado = 3,
            [Description("Carro Reservado")]
            CarroReservado = 4,
            Realizada = 5,
            Cancelada = 6
        }
    }
}