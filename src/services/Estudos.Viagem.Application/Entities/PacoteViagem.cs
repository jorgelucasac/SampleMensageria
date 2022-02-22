using Estudos.Viagem.Application.ValueObjects;

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
            Status = StatusViagem.Agendada;
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

        public virtual Hospedagem Hospedagem { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Carro Carro { get; set; }

        public void AgendarViagem()
        {
            Status = StatusViagem.Agendada;
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

            var dataIda = Passagem.DataIda.ToDateTime(TimeOnly.Parse("00:00"));
            var dataVolta = Passagem.DataVolta.ToDateTime(TimeOnly.Parse("00:00"));
            var diarias = (dataVolta - dataIda).Days;
            Total = (diarias <= 0 ? 1 : diarias) * 500 * Passagem.QuantidadeViajantes;

            if (Hospedagem != null && Hospedagem.PrecoDiaria > 0)
                Total += Hospedagem.PrecoDiaria * diarias;

            if (Carro != null && Carro.PrecoDiaria > 0)
                Total += Carro.PrecoDiaria * diarias;
        }

        //TODO: Validar dados
    }
    public enum StatusViagem
    {
        Agendada = 1,
        Realizada = 2,
        Cancelada = 3
    }
}