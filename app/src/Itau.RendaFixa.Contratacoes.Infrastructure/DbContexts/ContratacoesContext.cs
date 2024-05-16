using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Microsoft.EntityFrameworkCore;

namespace Itau.RendaFixa.Contratacoes.Infrastructure.DbContexts
{
    public class ContratacoesContext : DbContext, IContratacaoDbContext
    {
        public IQueryable<TipoProduto> TipoProdutos => Set<TipoProduto>();
        public IQueryable<Produto> Produtos => Set<Produto>();
        public IQueryable<Contratante> Contratantes => Set<Contratante>();
        public IQueryable<Contratacao> Contratacoes => Set<Contratacao>();      

        public ContratacoesContext(DbContextOptions<ContratacoesContext> opts) : base(opts)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public Task AddAsync<T>(T model, CancellationToken cancellationToken = default) where T : class
            => AddAsync(model, cancellationToken);

        public Task AddAsync<T>(IEnumerable<T> models, CancellationToken cancellationToken = default) where T : class
            => AddRangeAsync(models, cancellationToken);

        public Task UpdateAsync<T>(T model, CancellationToken cancellationToken = default) where T : class
            => UpdateAsync(model, cancellationToken);

        public void UpdateRange<T>(IEnumerable<T> models) where T : class
            => UpdateRange(models);
        public Task DeleteAsync<T>(T model, CancellationToken cancellationToken = default) where T : class
            => DeleteAsync(model, cancellationToken);

        public Task DeleteAsync<T>(IEnumerable<T> models, CancellationToken cancellationToken = default) where T : class
            => DeleteAsync(models, cancellationToken);

        void IContratacaoDbContext.SaveChanges()
            => SaveChanges();
    }
}
