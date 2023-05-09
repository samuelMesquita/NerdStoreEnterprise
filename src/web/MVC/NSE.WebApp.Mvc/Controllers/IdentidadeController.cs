
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Controllers
{
    public class IdentidadeController : Controller
    {
        private readonly IAutenticacaoService _authenticationService;

        public IdentidadeController(IAutenticacaoService authenticationService)
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

            var response = await _authenticationService.Login(usuarioLogin);

            //if(!response) return View(usuarioLogin);

            await RealizarLoginAsync(response);

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

        private async Task RealizarLoginAsync(UsuarioRespostaLogin usuarioResposta)
        {
            var token = ObterTokenFormatado(usuarioResposta.AccessToken);

            var claims = new List<Claim>();

            claims.Add(new Claim("JWT", usuarioResposta.AccessToken));

            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authenticationProperty = new AuthenticationProperties()
            {
                ExpiresUtc = System.DateTimeOffset.UtcNow.AddMinutes(60),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authenticationProperty);
        }

        private static JwtSecurityToken ObterTokenFormatado(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        }
    }
}
