using NSE.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public interface IAuthenticationService
    {
        Task<string> Login(UsuarioLogin usuarioLogin);
        Task<string> Register(UsuarioRegistro usuarioRegistro);
    }
}
