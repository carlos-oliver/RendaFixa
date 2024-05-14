using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AtualizarContratacao
{
    public class AtualizarContratacaoUseCase : IAtualizarContratacaoUseCase
    {
        private readonly ContratacoesContext _context;
        // variavel nao utilizada deve ser removida
        private readonly IMapper _mapper;

        public AtualizarContratacaoUseCase(ContratacoesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
 
        public async Task AtualizarContratacao(RealizarContratacaoViewModel contratacao, CancellationToken cancellationToken = default)
        {
            var contratacaoQuery = await Consultarcontratacao(contratacao.IdContratante, contratacao.IdProduto, DateOnly.FromDateTime(contratacao.DataOperacao), cancellationToken);
            // esta logica poderia estar no proprio objeto contratacao
            // contratacao.IncrementarQuantidade(10)
            contratacaoQuery.Quantidade += contratacao.Quantidade;
            contratacaoQuery.ValorUnitario += contratacao.ValorUnitario;

            _context.Contratacoes.Update(contratacaoQuery);
            // SaveChangesAsync retorna o numero de linhas afetadas, voce poderia logar isso para facilitar analise de problemas
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Contratacao> Consultarcontratacao(int idContratante, int idProduto, DateOnly dataOperacao, CancellationToken cancellationToken = default)
        {
            var query = _context.Contratacoes.AsQueryable();

            var contratacao = await query.Where(x =>
                x.IdContratante == idContratante &&
                x.IdProduto == idProduto &&
                DateOnly.FromDateTime(x.DataOperacao) == dataOperacao)
                .FirstOrDefaultAsync(cancellationToken);

            return contratacao;
        }
    }
}
