namespace Estudos.Viagem.Application.Entities
{
    public class Carro : BaseEntity
    {
        public Guid CarroId { get; private set; }
        public string Modelo { get; private set; }
        public string Categoria { get; private set; }
        public decimal PrecoDiaria { get; private set; }
    }
}
