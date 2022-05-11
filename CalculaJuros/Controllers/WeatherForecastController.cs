using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalculaJuros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

     
        [HttpGet("/CalculaJuros")]
        public IEnumerable<ModelRequest> CalculaJuros(
        int valorinicial,
        int meses)
        {

            int valorFinal = Convert.ToInt32(valorinicial * 1 * meses);

            return Enumerable.Range(1, 1).Select(index => new ModelRequest
            {
               result = valorFinal
            })
            .ToArray();
        }
       
        [HttpGet("/ShowMethECode")]
        public IEnumerable<ModelRequest> ShowMethECode()
        {
            var UrlGit = "https://Google.com.br";

            return Enumerable.Range(1, 1).Select(index => new ModelRequest
            {
                url = UrlGit
            })
            .ToArray();
        }
    }
}
