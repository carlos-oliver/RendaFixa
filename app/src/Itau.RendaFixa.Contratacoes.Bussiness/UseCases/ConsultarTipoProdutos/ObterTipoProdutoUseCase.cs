using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos.ViewModels;
using System.Net;

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

        public async Task<(HttpStatusCode, DefaultResultViewModel<IEnumerable<TipoProdutoViewModel>>)> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var tipoProdutos = await _consultarTipoProdutoRepository.ConsultarAsync(cancellationToken);

            if (tipoProdutos is null)
            {
                var erros = new List<Notification>
                {
                    new Notification(NotificationLevel.Information, "001","Tipo produto não encontrado")
                };
                return (HttpStatusCode.NotFound, new DefaultResultViewModel<IEnumerable<TipoProdutoViewModel>>(erros));
            }

            var tipoProdutoViewModel = _mapper.Map<IEnumerable<TipoProdutoViewModel>>(tipoProdutos);
            var response = new DefaultResultViewModel<IEnumerable<TipoProdutoViewModel>>(tipoProdutoViewModel);

            return (HttpStatusCode.OK,response);
        }
    }
}
