using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos.ViewModels;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos
{
    public class ObterTipoProdutoUseCase : IObterTipoProdutoUseCase
    {
        private readonly IConsultarTipoProdutoRepository _consultarTipoProdutoRepository;
        private readonly IMapper _mapper;

        public ObterTipoProdutoUseCase(IConsultarTipoProdutoRepository consultarTipoProdutoRepository, IMapper mapper)
        {
            _consultarTipoProdutoRepository = consultarTipoProdutoRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<TipoProdutoViewModel>>> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var tipoProdutos = await _consultarTipoProdutoRepository.ConsultarAsync(cancellationToken);        

            var response = new ApiResponse<IEnumerable<TipoProdutoViewModel>>
            {
                Data = _mapper.Map<IEnumerable<TipoProdutoViewModel>>(tipoProdutos)
            };

            return response;
        }
    }
}
