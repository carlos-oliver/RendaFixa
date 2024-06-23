using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarProduto.ViewModels;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarNovoProduto
{
    public class CriarProdutoUseCase : ICriarProdutoUseCase
    {
        private readonly ICriarProdutoRepository _criarProdutoRepository;
        private readonly IMapper _mapper;

        public CriarProdutoUseCase(ICriarProdutoRepository criarProdutoRepository, IMapper mapper)
        {
            _criarProdutoRepository = criarProdutoRepository;
            _mapper = mapper;
        }

        public async Task<Produto> CriarProduto(CriarProdutoViewModel criarProdutoViewModel, CancellationToken cancellationToken = default)
        {
            Produto produto = _mapper.Map<Produto>(criarProdutoViewModel);
            await _criarProdutoRepository.Criar(produto, cancellationToken);
            return produto;
        }
    }
}
