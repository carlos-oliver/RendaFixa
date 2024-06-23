using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Infrastructure.Repositories
{
    public class CriarProdutoRepository : ICriarProdutoRepository
    {
        private readonly IContratacaoDbContext _dbContext;

        public CriarProdutoRepository(IContratacaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Produto> Criar(Produto produto, CancellationToken cancellationToken = default)
        {
             await _dbContext.AddAsync(produto, cancellationToken);
             await _dbContext.SaveChangesAsync(cancellationToken);
             return produto;
        }
    }
}
