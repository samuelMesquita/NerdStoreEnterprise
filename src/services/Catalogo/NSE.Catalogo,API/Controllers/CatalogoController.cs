using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Catalogo.API.Models;
using NSE.WebAPI.Core.Identidade;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Catalogo.API.Controllers
{
    [Route("catalogo")]
    [Authorize]
    public class CatalogoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public CatalogoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [AllowAnonymous()]
        [HttpGet("produtos")]
        public async Task<IEnumerable<Produto>> GetAllProduto()
        {
            return await _produtoRepository.ObterTodos();
        }

        [ClaimsAuthorize("Catalogo","Ler")]
        [HttpGet("produtos/{id}")]
        public async Task<Produto> GetProduto(Guid id)
        {
            return await _produtoRepository.ObterPorId(id);
        }

        [HttpPost("produtos/add")]
        public IActionResult AddProduto(Produto produto)
        {
            _produtoRepository.Adicionar(produto);

            return Ok();
        }
    }
}
