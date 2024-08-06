using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos.ViewModels;
using System.Net;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos
{
    public interface IObterTipoProdutoUseCase
    {
        Task<(HttpStatusCode, DefaultResultViewModel<IEnumerable<TipoProdutoViewModel>>)> ExecuteAsync(CancellationToken cancellationToken = default);
    }
}
