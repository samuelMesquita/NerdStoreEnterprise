using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.Mvc.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Controllers
{
    public class IdentidadeController : Controller
    {

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {

        }

        [HttpGet]
        [Route("criar-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("criar-conta")]
        public Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
        {

        }
    }
}
