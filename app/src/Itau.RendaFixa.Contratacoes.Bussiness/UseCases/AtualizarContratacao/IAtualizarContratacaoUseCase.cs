using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AtualizarContratacao;

public interface IAtualizarContratacaoUseCase
{
    Task<Contratacao> ConsultarContratacaoAsync(ConsultarContratacaoCommand command, CancellationToken cancellationToken = default);
    Task AtualizarContratacaoAsync(RealizarContratacaoViewModel contratacao, ConsultarContratacaoCommand command, CancellationToken cancellationToken = default);
}