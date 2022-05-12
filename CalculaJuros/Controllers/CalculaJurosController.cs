using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalculaJuros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
      
        
        private readonly ILogger<CalculaJurosController> _logger;

        public CalculaJurosController(ILogger<CalculaJurosController> logger)
        {
            _logger = logger;
        }

     
        [HttpGet("/CalculaJuros")]
        public  IEnumerable<CalculaJurosResponse> CalculaJuros(
        decimal valorinicial,
        int meses)
        {
            var json = "";
            using (WebClient wc = new WebClient())
            {
                 json = wc.DownloadString("https://localhost:5002/TaxasDeJuros");
                
            }
        
            decimal objTaxa = JsonSerializer.Deserialize<decimal>(json);
            
            var juros = objTaxa * valorinicial;

            decimal valorFinal = juros * meses + valorinicial;

            return Enumerable.Range(1, 1).Select(index => new CalculaJurosResponse
            {
                result = valorFinal
            })
            .ToArray();
           
        }
       
        [HttpGet("/ShowMethECode")]
        public IEnumerable<ShowMethECodelResponse> ShowMethECode()
        {
            var UrlGit = "https://github.com/poliGuimaraes/CalculaJuros.git";

            return Enumerable.Range(1, 1).Select(index => new ShowMethECodelResponse
            {
                url = UrlGit
            })
            .ToArray();
        }

    }
}
