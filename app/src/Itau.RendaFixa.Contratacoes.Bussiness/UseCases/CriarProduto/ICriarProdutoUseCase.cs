using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarProduto.ViewModels;
using System.Net;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarNovoProduto
{
    public interface ICriarProdutoUseCase
    {
        Task<(HttpStatusCode, DefaultResultViewModel<Produto>)> CriarProduto(CriarProdutoViewModel criarProdutoViewModel, CancellationToken cancellationToken = default);
    }
}
