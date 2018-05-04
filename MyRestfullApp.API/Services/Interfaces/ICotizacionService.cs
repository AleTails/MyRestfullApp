using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyRestfullApp.API.Services.Interfaces
{
    public interface ICotizacionService
    {
        Task<IActionResult> Cotizar();
    }
}