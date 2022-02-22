namespace Estudos.Viagem.Application.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente() { }

        public Cliente(string nome, string cpf, DateOnly dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            DataCadastro = DateTime.Now;
        }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateOnly DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
    }
}