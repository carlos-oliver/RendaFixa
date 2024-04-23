using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Itau.RendaFixa.Contratacoes.Api.Controllers
{
    public class ContratanteController : ControllerBase
    {
        private readonly ICriarContratanteUseCase _criarContranteUseCase;

        public ContratanteController(ICriarContratanteUseCase criarContranteUseCase)
        {
            _criarContranteUseCase = criarContranteUseCase;
        }

        [HttpPost("contratantes")]
        public async Task<IActionResult> CriarContratanteAsync([FromBody] CriarContratanteViewModel criarContrante, CancellationToken cancellationToken = default)
        {
            await _criarContranteUseCase.CriarContratante(criarContrante, cancellationToken);
            return StatusCode(201);
        }

        [HttpPatch]
        public IActionResult Patch() 
        {
            throw new NotImplementedException();
        }
    }
}
