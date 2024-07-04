using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto.ViewModels;
using System.Web.Http.OData;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto
{
    public class AlterarProdutoUseCase : IAlterarProdutoUseCase
    {
        private readonly IAtualizarProdutoRepository _atualizarProdutoRepository;
        private readonly IConsultarProdutoRepository _consultarProdutoRepository;
        private readonly IMapper _mapper;
        public AlterarProdutoUseCase(IMapper mapper, IAtualizarProdutoRepository atualizarProdutoRepository, IConsultarProdutoRepository consultarProdutoRepository)
        {
            _mapper = mapper;
            _atualizarProdutoRepository = atualizarProdutoRepository;
            _consultarProdutoRepository = consultarProdutoRepository;
        }

        public async Task<AlterarProdutoViewModel?> AlterarNomeProduto(Delta<AlterarProdutoViewModel> atualiza, int id, CancellationToken cancellationToken = default)
        {
            var query = await _consultarProdutoRepository.ConsultarAsync(cancellationToken);
            //// caso voce nao encontre o produto precisa garantir que o cliente receber um 404
            //// implementar um notification
            var produto = query.FirstOrDefault(x => x.Id == id);

            if (produto is null)
                return default;
            //// simplificar o processo de mapping
            ///Duvida como simplificar
            var produtoViewModel = _mapper.Map<AlterarProdutoViewModel>(produto);

            atualiza.Patch(produtoViewModel);

            _mapper.Map(produtoViewModel, produto);
            await _atualizarProdutoRepository.AtualizarAsync(produto, cancellationToken);
            return produtoViewModel;
        }
    }
}
