using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AtualizarContratacao;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Itau.RendaFixa.Contratacoes.Api.Controllers
{
    [ApiController]
    [Route("contratacoes")]
    public class ContratacaoController : ControllerBase
    {
        private readonly IRealizarContratacaoUseCase _realizarContratacaoUseCase;
        private readonly IAtualizarContratacaoUseCase _atualizarContratacaoUseCase;

        public ContratacaoController(IRealizarContratacaoUseCase realizarContratacaoUseCase, IAtualizarContratacaoUseCase atualizarContratacaoUseCase)
        {
            _realizarContratacaoUseCase = realizarContratacaoUseCase;
            _atualizarContratacaoUseCase = atualizarContratacaoUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> RealizarContratacaoAsync([FromBody] RealizarContratacaoViewModel realizarContratacao, CancellationToken cancellationToken = default)
        {

            var contratacao = await _atualizarContratacaoUseCase.Consultarcontratacao(realizarContratacao.IdContratante, 
                realizarContratacao.IdProduto, DateOnly.FromDateTime(realizarContratacao.DataOperacao), cancellationToken);

            if (contratacao != null)
            {
                await _atualizarContratacaoUseCase.AtualizarContratacao(realizarContratacao, cancellationToken);
            }
            else
            {
                var contratacaoViewModel = await _realizarContratacaoUseCase.RealizarContratacao(realizarContratacao, cancellationToken);

                if (contratacaoViewModel == null)
                    return BadRequest();

                if (!TryValidateModel(contratacaoViewModel))
                    return ValidationProblem(ModelState);
            }   
            // return Created();
            return StatusCode(201);
        }
        // faltou implementacao?
        [HttpPatch]
        public IActionResult Patch()
        {
            throw new NotImplementedException();
        }

    }
}
