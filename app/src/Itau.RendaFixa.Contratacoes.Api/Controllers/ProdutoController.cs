using Itau.RendaFixa.Contratacoes.Bussiness;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto.ViewModels;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarNovoProduto;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarProduto.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Itau.RendaFixa.Contratacoes.Api.Controllers
{
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IConsultarProdutoUseCase _consultarProdutoUseCase;
        private readonly ICriarProdutoUseCase _criarProduto;
        private readonly IAlterarProdutoUseCase _alterarProdutoUseCase;

        public ProdutoController(IAlterarProdutoUseCase alterarProdutoUseCase, IConsultarProdutoUseCase consultarProdutoUseCase, ICriarProdutoUseCase criarProduto)
        {
            _alterarProdutoUseCase = alterarProdutoUseCase;
            _consultarProdutoUseCase = consultarProdutoUseCase;
            _criarProduto = criarProduto;
        }

        [HttpGet("produtos")]
        public async Task<IActionResult> ObterProdutoAsync([FromQuery] string? nome, int porPagina = 50, CancellationToken cancellationToken = default)
        {
            var produtos = await _consultarProdutoUseCase.ObterProdutoAsync(nome, porPagina, cancellationToken);
            return Ok(produtos);
        }

        [HttpPost("produtos")]
        public async Task<IActionResult> CriarProdutoAsync([FromBody] CriarProdutoViewModel criarProduto, CancellationToken cancellationToken = default)
        {
            await _criarProduto.CriarProduto(criarProduto, cancellationToken);
            return StatusCode(201);
        }

        [HttpPatch("produtos")]
        [ProducesResponseType(typeof(DefaultResultViewModel), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<AlterarProdutoViewModel>> AlterarProdutoAsync([FromBody] AlterarProdutoViewModel atualiza, int id, CancellationToken cancellationToken = default)
        {
            var (httpStatusCode, produtoViewModel) = await _alterarProdutoUseCase.AlterarNomeProduto(atualiza, id, cancellationToken);
             return StatusCode((int)httpStatusCode, produtoViewModel); 
        }
    }
}
