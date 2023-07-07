using Microsoft.AspNetCore.Mvc;
using NSE.Catalogo.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Catalogo.API.Controllers
{
    [Route("catalogo")]
    public class CatalogoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public CatalogoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet("produtos")]
        public async Task<IEnumerable<Produto>> GetAllProduto()
        {
            return await _produtoRepository.ObterTodos();
        }

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
