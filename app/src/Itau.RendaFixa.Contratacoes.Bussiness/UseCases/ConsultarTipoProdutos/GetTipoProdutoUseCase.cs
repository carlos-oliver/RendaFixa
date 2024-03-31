using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Itau.RendaFixa.Contratacoes.Bussiness.Data.Dtos;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos;

using Microsoft.EntityFrameworkCore;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos
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

        public async Task<ApiResponse<List<TipoProdutoDto>>> ExecuteAsync()
        {
            var tipoProdutos = await _context.TipoProdutos.ToListAsync();
            var tipoProdutosDto = _mapper.Map<List<TipoProdutoDto>>(tipoProdutos);

            var response = new ApiResponse<List<TipoProdutoDto>>
            {
                Data = tipoProdutosDto
            };

            return response;
        }
    }
}
