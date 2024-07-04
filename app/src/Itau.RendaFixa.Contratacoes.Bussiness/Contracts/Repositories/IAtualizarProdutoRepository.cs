using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories
{
    public interface IAtualizarProdutoRepository
    {
        Task<Produto> AtualizarAsync(Produto produto, CancellationToken cancellation = default);
    }
}
