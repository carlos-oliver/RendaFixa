using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories
{
    public interface IConsultarTipoProdutoRepository
    {
        Task<IEnumerable<TipoProduto>> ConsultarAsync(CancellationToken cancellationToken = default);
    }
}
