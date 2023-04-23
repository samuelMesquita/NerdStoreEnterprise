using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NSE.Identidade.API.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Erros = new List<string>();
        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]> 
            {
                { "Mensagem", Erros.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(x => x.Errors);
            foreach (var erro in erros)
            {
                AdicionarErrosProcessamentos(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected void AdicionarErrosProcessamentos(string erro)
        {
            Erros.Add(erro);
        }

        protected void LimparErrosProcessamentos()
        {
            Erros.Clear();
        }

        protected bool OperacaoValida()
        {
            return !Erros.Any();
        }
    }
}
