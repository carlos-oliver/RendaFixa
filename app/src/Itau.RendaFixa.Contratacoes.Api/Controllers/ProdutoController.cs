using Itau.RendaFixa.Contratacoes.Bussiness.Data.Dtos;
using Itau.RendaFixa.Contratacoes.Bussiness.Filters;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarNovoProduto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace Itau.RendaFixa.Contratacoes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IConsultarProdutoUseCase _consultarProdutoUseCase;
        private readonly ICriarProduto _criarProduto;

        public ProdutoController(IConsultarProdutoUseCase consultarProdutoUseCase, ICriarProduto criarProduto)
        {
            _consultarProdutoUseCase = consultarProdutoUseCase;
            _criarProduto = criarProduto;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] string? nome, int take = 50)
        {
            var produtos = await _consultarProdutoUseCase.ObterProdutoAsync(nome!, take);
            return Ok(produtos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CriarProdutoDto criarProduto)
        {
            //try {
            //    _criarProduto.CriarProduto(criarProduto);
            //    return StatusCode(201);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            _criarProduto.CriarProduto(criarProduto);
            return StatusCode(201);
        }

        [HttpPatch]
        public IActionResult Path()
        {
            throw new NotImplementedException();
        }
    }
}
