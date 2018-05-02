using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyRestfullApp.API.Services.Interfaces
{
    public interface IMonedaService
    {
        Task<IActionResult> Cotizar();
    }
}