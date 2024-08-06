using Itau.RendaFixa.Contratacoes.Bussiness;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto.ViewModels;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante.ViewModels;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarProduto.ViewModels;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [ProducesResponseType(typeof(DefaultResultViewModel<>), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(CriarProdutoViewModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CriarContratanteAsync([FromBody] CriarContratanteViewModel criarContratante, CancellationToken cancellationToken = default)
        {
            var (httpStatusCode, contratante) = await _criarContranteUseCase.CriarContratante(criarContratante, cancellationToken);

            return StatusCode((int)httpStatusCode, contratante);
        }

        [HttpPatch]
        [ProducesResponseType(typeof(DefaultResultViewModel<>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(AlterarProdutoViewModel), (int)HttpStatusCode.Accepted)]
        public async Task<ActionResult<HabilitarContratanteViewModel>> AlterarContratanteAsync([FromBody] HabilitarContratanteViewModel contratante, string cpf, CancellationToken cancellationToken = default) 
        {
            var (httpStatusCode, contratanteViewModel) = await _habilitarContratanteUseCase.HabilitarContratante(contratante, cpf, cancellationToken);
                  
            return StatusCode((int)httpStatusCode, contratanteViewModel);
        }
    }
}
