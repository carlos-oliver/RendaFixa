using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos.ViewModels;
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

        public async Task<ApiResponse<IEnumerable<ConsultarProdutoViewModel>>> ObterProdutoAsync(string? nome, int take, CancellationToken cancellationToken = default)
        {

            var query = _context.Produtos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nome))
                query = query.AsNoTracking().Where(x => x.Nome!.ToLower() == nome.ToLower());

            var produtos = await query.Take(take).ToListAsync(cancellationToken);       

            var produtosDto = _mapper.Map<IEnumerable<ConsultarProdutoViewModel>>(produtos);

            var response = new ApiResponse<IEnumerable<ConsultarProdutoViewModel>>
            {
                Data = produtosDto
            };

            return response;
        }
    }
}
