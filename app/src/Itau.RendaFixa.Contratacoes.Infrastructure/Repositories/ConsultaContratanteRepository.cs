using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Infrastructure.Repositories
{
    public class ConsultaContratanteRepository : IConsultarContratanteRepository
    {
        private readonly IContratacaoDbContext _dbContext;
        public ConsultaContratanteRepository(IContratacaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contratante?> ConsultarContratanteAsync(int idContratante, CancellationToken cancellationToken = default)
        {
            return await _dbContext.GetByIdAsync<Contratante>(idContratante, cancellationToken);
        }
    }
}
