using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante.ViewModels;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.OData;

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
        // incluir o atribute com os possiveis resultados
        //Duvida
        // [ProducesResponseType()]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CriarContratanteAsync([FromBody] CriarContratanteViewModel criarContratante, CancellationToken cancellationToken = default)
        {
             var contratanteViewModel = await _criarContranteUseCase.CriarContratante(criarContratante, cancellationToken);

            if (!TryValidateModel(contratanteViewModel))
                return ValidationProblem(ModelState);

            return StatusCode(201);
        }

        [HttpPatch]
        public async Task<ActionResult<HabilitarContratanteViewModel>> AlterarContratanteAsync(Delta<HabilitarContratanteViewModel> contratante, string cpf, CancellationToken cancellationToken = default) 
        {
            var contratanteViewModel = await _habilitarContratanteUseCase.HabilitarContratante(contratante, cpf, cancellationToken);

            if(!TryValidateModel(contratanteViewModel))
                return ValidationProblem(ModelState);

            return Ok(contratanteViewModel);
        }
    }
}
