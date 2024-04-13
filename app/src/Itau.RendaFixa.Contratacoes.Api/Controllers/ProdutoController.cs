using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarNovoProduto;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarProduto.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Itau.RendaFixa.Contratacoes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IConsultarProdutoUseCase _consultarProdutoUseCase;
        private readonly ICriarProdutoUseCase _criarProduto;

        public ProdutoController(IConsultarProdutoUseCase consultarProdutoUseCase, ICriarProdutoUseCase criarProduto)
        {
            _consultarProdutoUseCase = consultarProdutoUseCase;
            _criarProduto = criarProduto;
        }

        [HttpGet]
        public async Task<IActionResult> ObterProdutoAsync([FromQuery] string? nome, int porPagina = 50, CancellationToken cancellationToken = default)
        {
            var produtos = await _consultarProdutoUseCase.ObterProdutoAsync(nome, porPagina, cancellationToken);
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<IActionResult> CriarProdutoAsync([FromBody] CriarProdutoViewModel criarProduto, CancellationToken cancellationToken = default)
        {
            //try {
            //    _criarProduto.CriarProduto(criarProduto);
            //    return StatusCode(201);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            await _criarProduto.CriarProduto(criarProduto, cancellationToken);
            return StatusCode(201);
        }

        [HttpPatch]
        public IActionResult Path()
        {
            throw new NotImplementedException();
        }
    }
}
