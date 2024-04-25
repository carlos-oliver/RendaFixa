using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Itau.RendaFixa.Contratacoes.Api.Controllers
{
    [ApiController]
    [Route("contratante")]
    public class ContratanteController : ControllerBase
    {
        private readonly ICriarContratanteUseCase _criarContranteUseCase;

        public ContratanteController(ICriarContratanteUseCase criarContranteUseCase)
        {
            _criarContranteUseCase = criarContranteUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CriarContratanteAsync([FromBody] CriarContratanteViewModel criarContratante, CancellationToken cancellationToken = default)
        {
             var contratanteViewModel = await _criarContranteUseCase.CriarContratante(criarContratante, cancellationToken);

            if (!TryValidateModel(contratanteViewModel))
                return ValidationProblem(ModelState);

            return StatusCode(201);
        }

        [HttpPatch]
        public IActionResult Patch() 
        {
            throw new NotImplementedException();
        }
    }
}
