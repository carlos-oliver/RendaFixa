using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Infrastructure.Repositories
{
    public class HabilitarContratanteRepository : IHabilitarContratanteRepository
    {
        private readonly IContratacaoDbContext _dbContext;
        public HabilitarContratanteRepository(IContratacaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Contratante> HabilitarAsync(Contratante contratante, CancellationToken cancellationToken = default)
        {
            _dbContext.Update(contratante);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return contratante;
        }
    }
}
