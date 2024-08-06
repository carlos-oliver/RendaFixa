using Itau.RendaFixa.Contratacoes.Bussiness;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace Itau.RendaFixa.Contratacoes.Api.Controllers
{
    [ApiController]
    public class TipoProdutoController : ControllerBase
    {
        private readonly IObterTipoProdutoUseCase  _obterTipoProdutoUseCase;

        public TipoProdutoController(IObterTipoProdutoUseCase obterTipoProdutoUseCase)
        {
            _obterTipoProdutoUseCase = obterTipoProdutoUseCase;
        }

        [HttpGet("tipos_produtos")]
        [ProducesResponseType(typeof(DefaultResultViewModel<>), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ConsultarProdutoViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RecuperarTipoProdutoAsync(CancellationToken cancellationToken = default)
        {
            var (httpStatusCode, result) = await _obterTipoProdutoUseCase.ExecuteAsync(cancellationToken);

            return StatusCode((int)httpStatusCode, result); 
        }
    }
}
