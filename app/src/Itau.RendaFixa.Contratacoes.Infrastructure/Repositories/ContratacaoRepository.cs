using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;


namespace Itau.RendaFixa.Contratacoes.Infrastructure.Repositories;

public class ContratacaoRepository : IContratacaoRepository
{
    private readonly IContratacaoDbContext _dbContext;

    public ContratacaoRepository(IContratacaoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Contratacao> CriarAsync(Contratacao contratacao, CancellationToken cancellationToken = default)
    {
        await _dbContext.AddAsync(contratacao, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return contratacao;
    }
}
