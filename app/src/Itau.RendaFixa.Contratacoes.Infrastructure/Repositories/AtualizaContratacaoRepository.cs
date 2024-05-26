using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Infrastructure.Repositories
{
    public class AtualizaContratacaoRepository : IAtualizaContratacaoRepository
    {
        private readonly IContratacaoDbContext _dbContext;
        public AtualizaContratacaoRepository(IContratacaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contratacao> AtualizaContratacaoAsync(Contratacao contratacao, CancellationToken cancellationToken = default)
        {
            _dbContext.Update(contratacao);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return contratacao;
        }
    }
}
