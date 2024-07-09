using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Infrastructure.Repositories
{
    public class ConsultarContratacaoRepository : IConsultarContratacaoRepository
    {
        private readonly IContratacaoDbContext _dbContext;
        public ConsultarContratacaoRepository(IContratacaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Contratacao>> ConsultarAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.GetAllAsync<Contratacao>();
        }
    }
}
