using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyRestfullApp.API.Enums;
using MyRestfullApp.API.Services;

namespace MyRestfullApp.API.Controllers
{
    [Route("MyRestfullApp/[controller]")]
    public class CotizacionController : Controller
    {
        [Route("{monedaType}")]
        public async Task<IActionResult> GetCotizacion(string monedaType)
        {
            if (Enum.TryParse<MonedaType>(monedaType, out var parsedMonedaType))
            {
                var moneda = new MonedaService(parsedMonedaType);
                return await moneda.Cotizar();
            }
            return await Task.FromResult(new BadRequestResult());
        }
    }
}
