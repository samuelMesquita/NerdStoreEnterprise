
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Controllers
{
    public class IdentidadeController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public IdentidadeController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

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
            if(!ModelState.IsValid) return View(usuarioLogin);

            var response = _authenticationService.Login(usuarioLogin);

            if(!response.IsCompletedSuccessfully) return View(usuarioLogin);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("criar-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("criar-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return View(usuarioRegistro);

            if (false) return View(usuarioRegistro);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("sair")]
        public async Task<IActionResult> Logout()
        {
            return View();
        }
    }
}
