using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AtualizarContratacao
{
    public interface IAtualizarContratacaoUseCase
    {
        Task<RealizarContratacaoViewModel> Consultarcontratacao(int idContratante, int idProduto, DateOnly dataOperacao,CancellationToken cancellationToken = default);
        Task AtualizarContratacao(RealizarContratacaoViewModel contratacao, CancellationToken cancellationToken);
    }
}
