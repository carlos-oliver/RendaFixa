using Itau.RendaFixa.Contratacoes.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Itau.RendaFixa.Contratacoes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoProdutoController : ControllerBase
    {
        private readonly IGetTipoProduto _getTipoProdutoUseCase;

        public TipoProdutoController(IGetTipoProduto getTipoProdutoUseCase)
        {
            _getTipoProdutoUseCase = getTipoProdutoUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> RecuperarTipoP()
        {
            var result = await _getTipoProdutoUseCase.ExecuteAsync();

            if (result?.Data?.Count == 0 ) { return NoContent(); };
            return Ok(result);
        }

    }
}
