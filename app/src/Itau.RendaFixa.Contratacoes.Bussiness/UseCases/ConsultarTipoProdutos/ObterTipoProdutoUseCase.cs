using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos
{
    public class ObterTipoProdutoUseCase : IObterTipoProdutoUseCase
    {
        private readonly ContratacoesContext _context;
        private readonly IMapper _mapper;

        public ObterTipoProdutoUseCase(ContratacoesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<TipoProdutoViewModel>>> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var tipoProdutos = await _context.TipoProdutos.ToListAsync(cancellationToken);
            
            var viewModels = _mapper.Map<List<TipoProdutoViewModel>>(tipoProdutos);

            var response = new ApiResponse<List<TipoProdutoViewModel>>
            {
                Data = viewModels
            };

            return response;
        }
    }
}
