using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Estudos.Viagem.WebApi.Extensions
{
    public class ControllerBaseCustom : ControllerBase
    {
        public override OkObjectResult Ok(object? value)
        {
            var response = JsonConvert.SerializeObject(value, Formatting.Indented);
            return new OkObjectResult(response);
        }
    }
}