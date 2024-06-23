using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories
{
    public interface IConsultarContratanteRepository
    {
        Task<Contratante?> ConsultarAsync(object idContratante, CancellationToken cancellationToken = default);
        Task<IEnumerable<Contratante>> ConsultarPorNomeAsync(CancellationToken cancellationToken = default);
    }
}
