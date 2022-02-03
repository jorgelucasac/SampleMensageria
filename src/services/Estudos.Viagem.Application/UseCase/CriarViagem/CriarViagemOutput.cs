namespace Estudos.Viagem.Application.UseCase.CriarViagem;

public class CriarViagemOutput
{
    public CriarViagemOutput()
    {
        _mensages = new List<string>();
        _erros = new List<string>();
    }

    public void AddMessage(string menssagem)
    {
        _mensages.Add(menssagem);
    }

    public void AddErro(string erro)
    {
        _erros.Add(erro);
    }

    private readonly List<string> _mensages;
    private List<string> _erros { get; }

    public IEnumerable<string> Mensages => _mensages.AsReadOnly();

    public IEnumerable<string> Erros => _erros.AsReadOnly();
    public bool Sucesso => !Erros.Any();
}