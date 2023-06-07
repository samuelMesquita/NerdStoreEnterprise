using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.Mvc.Models;
using System.Linq;

namespace NSE.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
       protected bool ResponsePossuiErros(ResponseResult response)
        {
            if (response != null && response.Value.Errors.Mensagem.Any())
            {
                return true;
            }

            return false;
        }
    }
}
