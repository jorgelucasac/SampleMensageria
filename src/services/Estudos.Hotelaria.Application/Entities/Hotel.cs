namespace Estudos.Hotelaria.Application.Entities
{
    public class Hotel : BaseEntity
    {
        public Hotel(string nome, string cidade, TipoAcomodacao tipoAcomodacao, decimal valorDiaria, int quantidadeQuartos)
        {
            Nome = nome;
            Cidade = cidade;
            TipoAcomodacao = tipoAcomodacao;
            ValorDiaria = valorDiaria;
            QuantidadeQuartos = quantidadeQuartos;
            DataCadastro = DateTime.Now;
        }

        public string Nome { get; private set; }

        public string Cidade { get; private set; }

        public TipoAcomodacao TipoAcomodacao { get; private set; }

        public decimal ValorDiaria { get; private set; }

        public int QuantidadeQuartos { get; private set; }

        public int QuantidadeQuartosOcupados { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public void AdicionarReserva(int quantidadeQuartos)
        {
            QuantidadeQuartosOcupados += quantidadeQuartos;
        }

        public void RemoverReserva(int quantidadeQuartos)
        {
            QuantidadeQuartosOcupados -= quantidadeQuartos;
        }
    }

    public enum TipoAcomodacao
    {
        Solteiro,
        Casal
    }
}
