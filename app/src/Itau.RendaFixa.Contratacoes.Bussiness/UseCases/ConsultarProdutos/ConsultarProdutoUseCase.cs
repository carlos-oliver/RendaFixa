using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos.ViewModels;


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

        public async Task<ApiResponse<IEnumerable<ConsultarProdutoViewModel>>> ObterProdutoAsync(string? nome, int take, CancellationToken cancellationToken = default)
        {
            var query = await _consultarProdutoRepository.ConsultarPorNomeAsync(cancellationToken);
            //var query = _context.Produtos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nome))
                query = query.Where(x => x.Nome!.ToLower() == nome.ToLower());

            var produtos = query.Take(take).ToList();
            //// se utilizar a nomenclatura ViewModel, utilize somente elas, se Dto tbm so Dto
            ////var produtosDto = _mapper.Map<IEnumerable<ConsultarProdutoViewModel>>(produtos);

            var response = new ApiResponse<IEnumerable<ConsultarProdutoViewModel>>
            {
                Data = _mapper.Map<IEnumerable<ConsultarProdutoViewModel>>(produtos)
            };

            return response;
        }
    }
}
