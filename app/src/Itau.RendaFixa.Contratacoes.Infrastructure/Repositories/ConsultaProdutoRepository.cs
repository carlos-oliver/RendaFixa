using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Infrastructure.Repositories
{
    public class ConsultaProdutoRepository : IConsultarProdutoRepository
    {
        private readonly IContratacaoDbContext _dbContext;

        public ConsultaProdutoRepository(IContratacaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Produto?> ConsultarPorIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.GetByIdAsync<Produto>(id, cancellationToken);
        }

    }
}
