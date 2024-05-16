using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AtualizarContratacao;

public interface IAtualizarContratacaoUseCase
{
    Task<Contratacao> Consultarcontratacao(int idContratante, int idProduto, DateOnly dataOperacao,CancellationToken cancellationToken = default);
    Task<Contratacao> ConsultarContratacaoAsync(ConsultarContratacaoCommand command, CancellationToken cancellationToken = default);
}