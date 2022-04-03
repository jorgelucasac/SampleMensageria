using Estudos.Viagem.Application.UseCase.ObterViagens;
using Estudos.Viagem.Core.Extensions;
using Estudos.Viagem.Domain.ValueObjects;
using Newtonsoft.Json;

namespace Estudos.Viagem.WebApi.Responses
{
    public class ObterViagensResponse
    {
        public Guid Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public string DataIda { get; set; }
        public string DataVolta { get; set; }
        public int QuantidadeViajantes { get; set; }
        public string Nome { get; set; }
        public Guid ClienteId { get; set; }
        public HotelResponse? Hotel { get; set; }
        public CarroResponse? Carro { get; set; }
        public string Total { get; set; }
        public string Status { get; set; }
        public string DataCadastro { get; set; }
        public string DataUltimaAtualizacao { get; set; }
        public IList<ValidateResut> MensagensValidacoes { get; set; }

        public static IList<ObterViagensResponse> OutputToResponse(ObterViagensOutput output)
        {
            if (output.Data == null || !output.Data.Any())
                return new List<ObterViagensResponse>();

            return output.Data.Select(x => new ObterViagensResponse
            {
                Id = x.Id,
                Origem = x.Passagem.Origem,
                Destino = x.Passagem.Destino,
                DataIda = x.Passagem.DataIda.ToString(),
                DataVolta = x.Passagem.DataVolta.ToString(),
                QuantidadeViajantes = x.Passagem.QuantidadeViajantes,
                Nome = x.Cliente.Nome,
                ClienteId = x.ClienteId,
                Hotel = ToHotel(x.Hospedagem),
                Carro = ToCarro(x.Carro),
                Total = x.Total.ToString("C"),
                Status = x.Status.GetDescription(),
                DataCadastro = x.DataCadastro.ToString("dd/MM/yyyy HH:mm:dd"),
                DataUltimaAtualizacao = x.DataUltimaAtualizacao.ToString("dd/MM/yyyy HH:mm:dd"),
                MensagensValidacoes = ToValidateResult(x.MensagensValidacoes)
            }).ToList();
        }

        private static HotelResponse? ToHotel(Hospedagem? hospedagem)
        {
            if (hospedagem == null) return null;

            return new HotelResponse(hospedagem.HotelId, hospedagem.NomeHotel);
        }

        private static CarroResponse? ToCarro(Carro? carro)
        {
            if (carro == null) return null;

            return new CarroResponse(carro.CarroId, carro.Modelo, carro.Categoria);
        }

        private static IList<ValidateResut> ToValidateResult(string? messages)
        {
            try
            {
                if (string.IsNullOrEmpty(messages)) return new List<ValidateResut>();

                var validationMessages = JsonConvert.DeserializeObject<List<ValidateResut>>(messages);

                if (validationMessages == null) return new List<ValidateResut>();

                return validationMessages;
            }
            catch (Exception)
            {
                return new List<ValidateResut>();
            }
        }
    }

    public class HotelResponse
    {
        public HotelResponse(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
    }

    public class CarroResponse
    {
        public CarroResponse(Guid id, string modelo, string categoria)
        {
            Id = id;
            Modelo = modelo;
            Categoria = categoria;
        }

        public Guid Id { get; set; }
        public string Modelo { get; set; }
        public string Categoria { get; set; }
    }
}

