using System;
using Microsoft.AspNetCore.Mvc;

namespace APITemperaturas.Controllers
{
    [Route("api/[controller]")]
    public class ConversorTemperaturasController : Controller
    {
        [HttpGet("Fahrenheit/{temperatura}")]
        public object GetConversaoFahrenheit(double temperatura)
        {
            Temperatura dados = new Temperatura();
            dados.ValorFahrenheit = temperatura;
            dados.ValorCelsius =
                Math.Round((temperatura - 32.0) / 1.8, 2);
            dados.ValorKelvin = dados.ValorCelsius + 273.15;

            return dados;
        }
    }
}
