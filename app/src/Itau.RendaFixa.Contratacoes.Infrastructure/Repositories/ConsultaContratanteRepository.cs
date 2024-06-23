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

        public async Task<Contratante?> ConsultarAsync(object idContratante, CancellationToken cancellationToken = default)
        {
            return await _dbContext.GetByIdAsync<Contratante>(idContratante, cancellationToken);
        }

        public async Task<IEnumerable<Contratante>> ConsultarPorNomeAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.GetAllAsync<Contratante>(cancellationToken);
        }
    }
}
