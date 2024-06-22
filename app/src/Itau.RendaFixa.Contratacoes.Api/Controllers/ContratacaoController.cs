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

            var command = new ConsultarContratacaoCommandBuilder()
                .WithIdContratante(realizarContratacao.IdContratante)
                .WithIdProduto(realizarContratacao.IdProduto)
                .WithDataOperacao(realizarContratacao.DataOperacao)
                .Build();

            var contratacao = await _atualizarContratacaoUseCase.ConsultarContratacaoAsync(command, cancellationToken);

            if (contratacao is not null)
                await _atualizarContratacaoUseCase.AtualizarContratacaoAsync(realizarContratacao, command, cancellationToken);
            else
            {
                var contratacaoViewModel = await _realizarContratacaoUseCase.RealizarContratacao(realizarContratacao, cancellationToken);
                // substituir FluentValidation
            //    if (contratacaoViewModel == null)
            //        return BadRequest(new
            //        {
            //            Errors = new[]
            //            {
            //                new
            //                {
            //                    Code = "00001",
            //                    Message = "CARLOS NAO SEI "
            //                },
            //                new
            //                {
            //                    Code = "00001",
            //                    Message = "CARLOS NAO SEI "
            //                }
            //            }
            //        });

            //    if (!TryValidateModel(contratacaoViewModel))
            //        return ValidationProblem(ModelState);
            }   
             //return Created();
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
