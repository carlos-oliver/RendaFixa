using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarProduto.ViewModels;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarNovoProduto
{
    public interface ICriarProdutoUseCase
    {
        Task<Produto> CriarProduto(CriarProdutoViewModel criarProdutoViewModel, CancellationToken cancellationToken = default);
    }
}
