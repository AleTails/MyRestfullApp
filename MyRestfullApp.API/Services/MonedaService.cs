using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyRestfullApp.API.Enums;
using MyRestfullApp.API.Services.Interfaces;

namespace MyRestfullApp.API.Services
{
    public class MonedaService : IMonedaService
    {
        private readonly ICotizacionService _cotizacionMethod;

        public MonedaService(MonedaType monedaType)
        {
            switch (monedaType)
            {
                case MonedaType.Dolar:
                    _cotizacionMethod = new CotizacionDolarService();
                    break;
                case MonedaType.Real:
                    _cotizacionMethod = new CotizacionRealService();
                    break;
                case MonedaType.Peso:
                    _cotizacionMethod = new CotizacionPesoService();
                    break;
            }
        }

        public async Task<IActionResult> Cotizar()
        {
            return await _cotizacionMethod.Cotizar();
        }
    }
}