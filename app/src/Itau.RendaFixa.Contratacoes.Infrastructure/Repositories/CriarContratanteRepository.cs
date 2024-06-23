using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Infrastructure.Repositories
{
    public class CriarContratanteRepository : ICriarContratanteRepository
    {
        private readonly IContratacaoDbContext _dbContext;

        public CriarContratanteRepository(IContratacaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contratante> Criar(Contratante contratante, CancellationToken cancellation = default)
        {
            await _dbContext.AddAsync(contratante);
            await _dbContext.SaveChangesAsync();
            return contratante;
        }
    }
}
