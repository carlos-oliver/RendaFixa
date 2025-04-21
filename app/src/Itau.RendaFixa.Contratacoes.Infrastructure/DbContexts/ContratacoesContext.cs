using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Infrastructure.Configuration;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TipoProduto>().ToTable("tipos_produtos")
                .HasKey(c => c.Id)
                .HasName("id");

            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());

            modelBuilder.Entity<Contratante>().ToTable("contratantes")
                .HasKey(c => c.Id)
                .HasName("id");

            modelBuilder.Entity<Contratacao>().ToTable("contratacoes")
                .HasKey(c => c.Id)
                .HasName("id");
        }

        public async Task AddAsync<T>(T model, CancellationToken cancellationToken = default) where T : class
            => await base.AddAsync(model, cancellationToken);
        
        public async Task AddAsync<T>(IEnumerable<T> models, CancellationToken cancellationToken = default) where T : class
            => await base.AddRangeAsync(models, cancellationToken);

        public void Update<T>(T model) where T : class
            => base.Update(model);

        public void UpdateRange<T>(IEnumerable<T> models) where T : class
            => UpdateRange(models);
        public async Task DeleteAsync<T>(T model, CancellationToken cancellationToken = default) where T : class
            => await DeleteAsync(model, cancellationToken);

        public async Task DeleteAsync<T>(IEnumerable<T> models, CancellationToken cancellationToken = default) where T : class
            => await DeleteAsync(models, cancellationToken);

        public async Task<IEnumerable<T>> GetAllAsync<T>(CancellationToken cancellationToken = default) where T : class
            => await Set<T>().AsQueryable().ToListAsync(cancellationToken);

        public async Task<T?> GetByIdAsync<T>(object id, CancellationToken cancellationToken = default) where T : class
            => await Set<T>().FindAsync(new object[] { id }, cancellationToken);
        
        void IContratacaoDbContext.SaveChanges()
            => SaveChanges();

    }
}
