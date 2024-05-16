using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao
{
    // isto poderia ser um repository
    public class ConsultarContratanteBloqueadoUseCase : IConsultarContratanteBloqueadoUseCase
    {
        private readonly IContratacaoDbContext _context;

        public ConsultarContratanteBloqueadoUseCase(IContratacaoDbContext context)
        {
            _context = context;
        }

        public Task<bool> ConsultarContratante(int idContratante, CancellationToken cancellationToken = default)
        {
            var query = _context.Contratantes.AsQueryable();

            query = query.Where(x => x.Id == idContratante && x.Habilitado == true);

            if (query.Count() > 0) 
                return Task.FromResult(true);

            return Task.FromResult(false);
        }
    }
}
