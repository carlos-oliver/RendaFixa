using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Infrastructure.Repositories
{
    public class AtualizarProdutoRepository : IAtualizarProdutoRepository
    {
        private readonly IContratacaoDbContext _DbContext;
        public AtualizarProdutoRepository(IContratacaoDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<Produto> AtualizarAsync(Produto produto, CancellationToken cancellation = default)
        {
            _DbContext.Update(produto);
            await _DbContext.SaveChangesAsync();
            return produto;
        }
    }
}
