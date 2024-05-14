using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Microsoft.EntityFrameworkCore;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao
{
    // isto poderia ser um repository
    public class ConsultarProdutoBloqueadoUseCase : IConsultarProdutoBloqueadoUseCase
    {
        private readonly ContratacoesContext _context;

        public ConsultarProdutoBloqueadoUseCase(ContratacoesContext context)
        {
            _context = context;       
        }

        public async Task<bool> ConsultarProduto(int id, CancellationToken cancellationToken = default)
        {
            var query = _context.Produtos.AsQueryable();

            query =  query.AsNoTracking().Where(x => x.Id == id && x.Bloqueado == true);

            if (await query.CountAsync() > 0) 
                return true;
            
            return false;
        }
    }
}
