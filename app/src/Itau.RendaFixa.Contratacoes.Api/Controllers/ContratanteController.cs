using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante.ViewModels;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Itau.RendaFixa.Contratacoes.Api.Controllers
{
    [ApiController]
    [Route("contratante")]
    public class ContratanteController : ControllerBase
    {
        private readonly ICriarContratanteUseCase _criarContranteUseCase;
        private readonly IHabilitarContratanteUseCase _habilitarContratanteUseCase;

        public ContratanteController(ICriarContratanteUseCase criarContranteUseCase, IHabilitarContratanteUseCase habilitarContratanteUseCase)
        {
            _criarContranteUseCase = criarContranteUseCase;
            _habilitarContratanteUseCase = habilitarContratanteUseCase;
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
        public async Task<ActionResult<HabilitarContratanteViewModel>> AlterarContratanteAsync([FromBody] JsonPatchDocument<HabilitarContratanteViewModel> patch, string cpf, CancellationToken cancellationToken = default) 
        {
            var contratanteViewModel = await _habilitarContratanteUseCase.HabilitarContratante(patch, cpf, cancellationToken);

            if(!TryValidateModel(contratanteViewModel))
                return ValidationProblem(ModelState);

            return Ok(contratanteViewModel);
        }
    }
}
