namespace Estudos.Viagem.WebApi.Responses
{
    public class ValidateResut
    {
        public ValidateResut(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }

        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}

