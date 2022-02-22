using Estudos.Viagem.Application.UseCase.CadastrarCliente;
using System.ComponentModel.DataAnnotations;

namespace Estudos.Viagem.WebApi.Requests
{
    public class CadastrarClienteRequest
    {
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public DateTime DataNascimento { get; set; }

        public CadastrarClienteInput ToInput()
        {
            return new CadastrarClienteInput(Nome, Cpf, DateOnly.FromDateTime(DataNascimento));
        }
    }
}