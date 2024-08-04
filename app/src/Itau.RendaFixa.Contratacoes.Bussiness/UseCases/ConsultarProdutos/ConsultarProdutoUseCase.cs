using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos.ViewModels;
using System.Net;


namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos
{
    public class ConsultarProdutoUseCase : IConsultarProdutoUseCase
    {
        private readonly IMapper _mapper;
        private readonly IConsultarProdutoRepository _consultarProdutoRepository;

        public ConsultarProdutoUseCase(
            IMapper mapper,
            IConsultarProdutoRepository consultarProdutoRepository)
        {
            _mapper = mapper;
            _consultarProdutoRepository = consultarProdutoRepository;
        }

        public async Task<(HttpStatusCode, DefaultResultViewModel<IEnumerable<ConsultarProdutoViewModel>>)> ObterProdutoAsync(string? nome, int take, CancellationToken cancellationToken = default)
        {
            var query = await _consultarProdutoRepository.ConsultarAsync(cancellationToken);

            if (!string.IsNullOrWhiteSpace(nome))
                query = query.Where(x => x.Nome!.ToLower() == nome.ToLower());

            var produtos = query.Take(take).ToList();
            var produtosViewModel = _mapper.Map<IEnumerable<ConsultarProdutoViewModel>>(produtos);

            var response = new DefaultResultViewModel<IEnumerable<ConsultarProdutoViewModel>>(produtosViewModel);

            return (HttpStatusCode.OK, response);
        }
    }
}
