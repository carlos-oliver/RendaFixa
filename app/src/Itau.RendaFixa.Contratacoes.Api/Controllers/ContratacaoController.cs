using Itau.RendaFixa.Contratacoes.Bussiness;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AtualizarContratacao;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarProduto.ViewModels;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [ProducesResponseType(typeof(DefaultResultViewModel<>), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(CriarProdutoViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(CriarProdutoViewModel), (int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> RealizarContratacaoAsync([FromBody] RealizarContratacaoViewModel realizarContratacao, CancellationToken cancellationToken = default)
        {

            var command = new ConsultarContratacaoCommandBuilder()
                .WithIdContratante(realizarContratacao.IdContratante)
                .WithIdProduto(realizarContratacao.IdProduto)
                .WithDataOperacao(realizarContratacao.DataOperacao)
                .Build();

            var contratacao = await _atualizarContratacaoUseCase.ConsultarContratacaoAsync(command, cancellationToken);

            if (contratacao is not null)
            {
                var (httpStatusCode, atualizarContratacao) = await _atualizarContratacaoUseCase.AtualizarContratacaoAsync(realizarContratacao, command, cancellationToken);
                return StatusCode((int)httpStatusCode, atualizarContratacao);
            }
            else
            {
                var(httpStatusCode, contratacaoViewModel) = await _realizarContratacaoUseCase.RealizarContratacao(realizarContratacao, cancellationToken);
                return StatusCode((int)httpStatusCode, contratacaoViewModel);
            }
        }
        // faltou implementacao?
        [HttpPatch]
        public IActionResult Patch()
        {
            throw new NotImplementedException();
        }

    }
}
