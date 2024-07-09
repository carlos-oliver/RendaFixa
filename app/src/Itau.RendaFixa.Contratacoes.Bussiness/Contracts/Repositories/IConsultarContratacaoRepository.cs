using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories
{
    public interface IConsultarContratacaoRepository
    {
        Task<IEnumerable<Contratacao>> ConsultarAsync(CancellationToken cancellationToken = default);
    }
}
