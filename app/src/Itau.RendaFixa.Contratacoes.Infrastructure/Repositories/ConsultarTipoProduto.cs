using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Infrastructure.Repositories
{
    public class ConsultarTipoProduto : IConsultarTipoProdutoRepository
    {
        private readonly IContratacaoDbContext _dbContext;
        public ConsultarTipoProduto(IContratacaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TipoProduto>> ConsultarAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.GetAllAsync<TipoProduto>();
        }
    }
}
