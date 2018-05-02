using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyRestfullApp.API.Dtos;
using MyRestfullApp.API.Services.Interfaces;
using Newtonsoft.Json;

namespace MyRestfullApp.API.Services
{
    public class CotizacionDolarService : ICotizacionService
    {
        private readonly HttpClient _client = new HttpClient();
        private const string CotizacionUrl = @"https://www.bancoprovincia.com.ar/Principal/dolar";

        public async Task<IActionResult> Cotizar()
        {
            var cotizazionResult = await _client.GetAsync(CotizacionUrl);
            var cotizacionArry = JsonConvert.DeserializeObject<string[]>(await cotizazionResult.Content.ReadAsStringAsync());
            if (cotizazionResult.IsSuccessStatusCode)
                return new OkObjectResult(new CotizacionDto(cotizacionArry));
            return new BadRequestObjectResult(cotizazionResult);
        }
    }
}
