using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AtualizarContratacao.ViewModel;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AtualizarContratacao
{
    public interface IAtualizarContratacaoUseCase
    {
        Task<ConsultarContratacaoViewModel> Consultarcontratacao(int idContratante, int idProduto, DateOnly dataOperacao,CancellationToken cancellationToken = default);
    }
}
