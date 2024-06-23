using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories
{
    public interface ICriarProdutoRepository
    {
        Task<Produto> Criar(Produto produto, CancellationToken cancellationToken = default);
    }
}
