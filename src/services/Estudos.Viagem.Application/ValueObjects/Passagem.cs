namespace Estudos.Viagem.Application.ValueObjects
{
    public class Passagem
    {
        public Passagem(string origem,
            string destino,
            DateOnly dataIda,
            DateOnly dataVolta,
            int quantidadeViajantes
        )
        {
            Origem = origem;
            Destino = destino;
            DataIda = dataIda;
            DataVolta = dataVolta;
            QuantidadeViajantes = quantidadeViajantes;
        }

        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateOnly DataIda { get; set; }
        public DateOnly DataVolta { get; set; }
        public int QuantidadeViajantes { get; set; }

        //TODO: Validar dados
    }
}