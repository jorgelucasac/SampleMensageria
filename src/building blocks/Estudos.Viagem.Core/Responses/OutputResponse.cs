using FluentValidation.Results;

namespace Estudos.Viagem.Core.Responses
{
    public abstract class OutputResponse<T> : ValidationResult where T : class
    {
        public void AddErro(string message, string key = null) => Errors.Add(new ValidationFailure(message, key));

        public string Message { get; set; }

        public bool Success => IsValid;

        public T Data { get; set; }

        public ResponseFormatted FormattedToApi()
        {
            var errors = new Dictionary<string, string>();
            if (Errors != null && Errors.Any())
                Errors.ToList().ForEach(e => errors.Add(e.PropertyName, e.ErrorMessage));

            return new ResponseFormatted(Message, errors, Data);
        }
    }

    public class ResponseFormatted
    {
        public ResponseFormatted(string message, IDictionary<string, string> errors, object data = null)
        {
            Message = message;
            Errors = errors;
            Data = data;
        }

        public string Message { get; set; }

        public IDictionary<string, string> Errors { get; set; }

        public object Data { get; set; }
    }
}