using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories
{
    public interface IConsultarContratanteRepository
    {
        Task<Contratante?> ConsultarAsync(int idContratante, CancellationToken cancellationToken = default);
    }
}
