using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories
{
    public interface IContratacaoRepository
    {
        Task<Contratacao> CriarAsync(Contratacao contratacao, CancellationToken cancellationToken = default);
    }
}