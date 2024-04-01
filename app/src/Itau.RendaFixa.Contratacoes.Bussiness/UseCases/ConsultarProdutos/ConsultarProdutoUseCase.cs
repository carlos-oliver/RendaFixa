using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Itau.RendaFixa.Contratacoes.Bussiness.Data.Dtos;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Microsoft.EntityFrameworkCore;


namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos
{
    public class ConsultarProdutoUseCase : IConsultarProdutoUseCase
    {
        private readonly ContratacoesContext _context;
        private readonly IMapper _mapper;

        public ConsultarProdutoUseCase(ContratacoesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ProdutosDto>>> ObterProdutoAsync(string? nome, int take)
        {

            var query = _context.Produtos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nome))
                query = query.Where(x => x.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            var produtos = query.Take(take).ToListAsync();
          
            var produtosDto = _mapper.Map<IEnumerable<ProdutosDto>>(produtos);

            var response = new ApiResponse<IEnumerable<ProdutosDto>>
            {
                Data = produtosDto
            };

            return response;

        }
    }
}
