using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos.ViewModels;
using Itau.RendaFixa.Contratacoes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;

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

        public async Task<ApiResponse<IEnumerable<Produtos>>> ObterProdutoAsync(string nome)
        {
            var produtosList = await _context.Produtos
                 .Where(p => string.IsNullOrEmpty(nome) || p.Nome == nome)
                 .ToListAsync();

            var produtosDto = _mapper.Map<IEnumerable<Produtos>>(produtosList);

            var response = new ApiResponse<IEnumerable<Produtos>>
            {
                Data = produtosDto
            };

            return response;

        }
    }
}
