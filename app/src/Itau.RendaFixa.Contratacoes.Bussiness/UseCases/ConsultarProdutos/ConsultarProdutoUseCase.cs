using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos.ViewModels;
using Itau.RendaFixa.Contratacoes.Infrastructure.Data;
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

        public async Task<ApiResponse<Produtos>> ObterProdutoAsync(string nome)
        {
            var produtosList = await _context.Produtos.ToListAsync();


            var produto = produtosList.FirstOrDefault(produto => produto.Nome == nome);
            var produtosDto = _mapper.Map<Produtos>(produto);

            var response = new ApiResponse<Produtos>
            {
                Data = produtosDto
            };

            return response;
        }
    }
}
