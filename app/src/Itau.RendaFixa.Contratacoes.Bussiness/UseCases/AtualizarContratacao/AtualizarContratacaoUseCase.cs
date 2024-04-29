using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AtualizarContratacao.ViewModel;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AtualizarContratacao
{
    public class AtualizarContratacaoUseCase : IAtualizarContratacaoUseCase
    {
        private readonly ContratacoesContext _context;
        private readonly IMapper _mapper;

        public AtualizarContratacaoUseCase(ContratacoesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ConsultarContratacaoViewModel> Consultarcontratacao(int idContratante, int idProduto, CancellationToken cancellationToken = default)
        {
            var query = _context.Contratacoes.AsQueryable();

            var contratacao = await query.Where(x => x.IdContratante == idContratante && x.IdProduto == idProduto).FirstOrDefaultAsync(cancellationToken);

            var contratacaoModel = _mapper.Map<ConsultarContratacaoViewModel>(contratacao);

            return contratacaoModel;
        }
    }
}
