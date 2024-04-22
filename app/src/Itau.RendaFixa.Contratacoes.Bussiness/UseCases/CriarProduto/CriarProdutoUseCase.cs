using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarProduto.ViewModels;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarNovoProduto
{
    public class CriarProdutoUseCase : ICriarProdutoUseCase
    {
        private readonly ContratacoesContext _context;
        private readonly IMapper _mapper;

        public CriarProdutoUseCase(ContratacoesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Produto> CriarProduto(CriarProdutoViewModel criarProdutoViewModel, CancellationToken cancellationToken = default)
        {
            Produto produto = _mapper.Map<Produto>(criarProdutoViewModel);
            await _context.Produtos.AddAsync(produto, cancellationToken);
            _context.SaveChanges();
            return produto;
        }
    }
}
