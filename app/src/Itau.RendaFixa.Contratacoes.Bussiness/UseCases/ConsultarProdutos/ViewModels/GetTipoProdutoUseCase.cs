using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos.ViewModels
{
    public class GetTipoProdutoUseCase : IGetTipoProduto
    {
        private readonly ContratacoesContext _context;
        private readonly IMapper _mapper;

        public GetTipoProdutoUseCase(ContratacoesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<TipoProduto>>> ExecuteAsync()
        {
            var tipoProdutos = await _context.TipoProdutos.ToListAsync();
            var tipoProdutosDto = _mapper.Map<List<TipoProduto>>(tipoProdutos);

            var response = new ApiResponse<List<TipoProduto>>
            {
                Data = tipoProdutosDto
            };

            return response;
        }
    }
}
