using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos.ViewModels;
using System.Net;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos
{
    public interface IConsultarProdutoUseCase
    {
        Task<(HttpStatusCode, DefaultResultViewModel<IEnumerable<ConsultarProdutoViewModel>>)> ObterProdutoAsync(string? nome, int take, CancellationToken cancellationToken = default);
    }
}
