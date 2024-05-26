using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;

public interface IContratacaoDbContext
{
    IQueryable<TipoProduto> TipoProdutos { get; }
    IQueryable<Produto> Produtos { get; }
    IQueryable<Contratante> Contratantes { get; }
    IQueryable<Contratacao> Contratacoes { get; }
    Task AddAsync<T>(T model, CancellationToken cancellationToken = default) where T: class;
    Task AddAsync<T>(IEnumerable<T> models, CancellationToken cancellationToken = default) where T: class;
    void Update<T>(T model) where T: class;
    void UpdateRange<T>(IEnumerable<T> models) where T: class;
    Task DeleteAsync<T>(T model, CancellationToken cancellationToken = default) where T: class;
    Task DeleteAsync<T>(IEnumerable<T> models, CancellationToken cancellationToken = default) where T: class;
    Task<IEnumerable<T>> GetAllAsync<T>(CancellationToken cancellationToken = default) where T : class;
    Task<T?> GetByIdAsync<T>(object id, CancellationToken cancellationToken = default) where T : class;
    void SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}