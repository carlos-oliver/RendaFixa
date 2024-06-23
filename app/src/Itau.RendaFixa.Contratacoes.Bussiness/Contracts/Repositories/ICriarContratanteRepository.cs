using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories
{
    public interface ICriarContratanteRepository
    {
        Task<Contratante> Criar(Contratante contratante, CancellationToken cancellation = default);
    }
}
