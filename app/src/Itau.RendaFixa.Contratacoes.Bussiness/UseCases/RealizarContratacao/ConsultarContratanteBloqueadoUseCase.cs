using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Microsoft.EntityFrameworkCore;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao
{
    public class ConsultarContratanteBloqueadoUseCase : IConsultarContratanteBloqueadoUseCase
    {
        private readonly ContratacoesContext _context;

        public ConsultarContratanteBloqueadoUseCase(ContratacoesContext context)
        {
            _context = context;
        }

        public async Task<bool> ConsultarContratante(int idContratante, CancellationToken cancellationToken = default)
        {
            var query = _context.Contratantes.AsQueryable();

            query = query.AsNoTracking().Where(x => x.Id == idContratante && x.Habilitado == true);

            if (await query.CountAsync() > 0) 
                return true;

            return false;
        }
    }
}
