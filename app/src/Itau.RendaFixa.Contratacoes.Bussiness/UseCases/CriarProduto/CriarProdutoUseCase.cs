using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarProduto.ViewModels;
using System.Net;

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

        public async Task<(HttpStatusCode, DefaultResultViewModel<Produto>)> CriarProduto(CriarProdutoViewModel criarProdutoViewModel, CancellationToken cancellationToken = default)
        {
            try
            {
                var produto = _mapper.Map<Produto>(criarProdutoViewModel);
                var resultado = await _criarProdutoRepository.Criar(produto, cancellationToken);
                return (HttpStatusCode.Created, new DefaultResultViewModel<Produto>(produto));
            }
            catch (Exception ex) 
            {
                var erros = new List<Notification>
                {
                    new Notification(NotificationLevel.Information, "001","Erro ao criar produto")
                };
                return (HttpStatusCode.InternalServerError, new DefaultResultViewModel<Produto>(erros));
            }
        }
    }
}
