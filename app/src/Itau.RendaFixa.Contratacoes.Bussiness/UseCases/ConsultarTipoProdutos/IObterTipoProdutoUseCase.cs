using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos.ViewModels;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos
{
    public interface IObterTipoProdutoUseCase
    {
        Task<ApiResponse<IEnumerable<TipoProdutoViewModel>>> ExecuteAsync(CancellationToken cancellationToken = default);
    }
}
