using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories
{
    public interface IHabilitarContratanteRepository
    {
        Task<Contratante> HabilitarAsync(Contratante contratante, CancellationToken cancellationToken = default);
    }
}
