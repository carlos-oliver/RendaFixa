using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories
{
    public interface IConsultarProdutoRepository
    {
        Task<Produto?> ConsultarPorIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Produto>> ConsultarPorNomeAsync(CancellationToken cancellationToken = default);

    }
}
