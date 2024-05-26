using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories
{
    public interface IAtualizaContratacaoRepository
    {
        Task<Contratacao> AtualizaContratacaoAsync(Contratacao contratacao, CancellationToken cancellationToken = default);
    }
}
