using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyRestfullApp.API.Services.Interfaces;

namespace MyRestfullApp.API.Services
{
    public class CotizacionRealService : ICotizacionService
    {
        public async Task<IActionResult> Cotizar()
        {
            return await Task.FromResult(new UnauthorizedResult());
        }
    }
}
