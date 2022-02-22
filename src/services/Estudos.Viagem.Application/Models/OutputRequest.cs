namespace Estudos.Viagem.Application.Models
{
    public abstract class OutputRequest
    {
        public void AddMessage(string menssagem)
        {
            _mensages.Add(menssagem);
        }

        public void AddErro(string erro)
        {
            _erros.Add(erro);
        }

        private readonly List<string> _mensages = new();
        private List<string> _erros { get; } = new List<string>();

        public IEnumerable<string> Mensages => _mensages.AsReadOnly();

        public IEnumerable<string> Erros => _erros.AsReadOnly();
        public bool Sucesso => !Erros.Any();
    }
}
