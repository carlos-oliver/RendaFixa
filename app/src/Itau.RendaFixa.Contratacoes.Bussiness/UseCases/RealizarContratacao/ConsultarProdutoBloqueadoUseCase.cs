using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;


namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao
{
    // isto poderia ser um repository
    public class ConsultarProdutoBloqueadoUseCase : IConsultarProdutoBloqueadoUseCase
    {
        private readonly IContratacaoDbContext _context;

        public ConsultarProdutoBloqueadoUseCase(IContratacaoDbContext context)
        {
            _context = context;       
        }

        public Task<bool> ConsultarProduto(int id, CancellationToken cancellationToken = default)
        {
            var query = _context.Produtos.AsQueryable();

            query =  query.Where(x => x.Id == id && x.Bloqueado == true);

            if (query.Count() > 0) 
                return Task.FromResult(true);

            return Task.FromResult(false);
        }
    }
}
