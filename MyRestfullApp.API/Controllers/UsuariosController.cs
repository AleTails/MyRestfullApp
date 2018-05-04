using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyRestfullApp.API.Controllers
{
    [Route("MyRestfullApp/[controller]")]
    public class UsuariosController : Controller
    {
        public async Task <IActionResult> GetUsuarios()
        {
            return View();
        }
    }
}