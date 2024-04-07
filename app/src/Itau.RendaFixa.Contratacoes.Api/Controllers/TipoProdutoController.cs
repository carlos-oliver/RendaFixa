using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos;
using Microsoft.AspNetCore.Mvc;


namespace Itau.RendaFixa.Contratacoes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoProdutoController : ControllerBase
    {
        private readonly IObterTipoProdutoUseCase  _obterTipoProdutoUseCase;

        public TipoProdutoController(IObterTipoProdutoUseCase obterTipoProdutoUseCase)
        {
            _obterTipoProdutoUseCase = obterTipoProdutoUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> RecuperarTipoProdutoAsync(CancellationToken cancellationToken = default)
        {
            var result = await _obterTipoProdutoUseCase.ExecuteAsync(cancellationToken);

            if (result.Data is not null && result.Data.Any())
                return Ok(result);

            return NoContent(); 
        }
    }
}
