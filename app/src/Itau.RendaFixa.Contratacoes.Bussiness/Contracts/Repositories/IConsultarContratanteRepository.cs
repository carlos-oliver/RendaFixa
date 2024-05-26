using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories
{
    public interface IConsultarContratanteRepository
    {
        Task<Contratante?> ConsultarContratanteAsync(int idContratante, CancellationToken cancellationToken = default);
    }
}
