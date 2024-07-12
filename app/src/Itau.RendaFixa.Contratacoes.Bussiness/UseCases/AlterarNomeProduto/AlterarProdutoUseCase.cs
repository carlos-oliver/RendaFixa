using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto.ViewModels;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto
{
    public class AlterarProdutoUseCase : IAlterarProdutoUseCase
    {
        private readonly IAtualizarProdutoRepository _atualizarProdutoRepository;
        private readonly IConsultarProdutoRepository _consultarProdutoRepository;
        public AlterarProdutoUseCase(IAtualizarProdutoRepository atualizarProdutoRepository, IConsultarProdutoRepository consultarProdutoRepository)
        {
            _atualizarProdutoRepository = atualizarProdutoRepository;
            _consultarProdutoRepository = consultarProdutoRepository;
        }

        public async Task<Produto?> AlterarNomeProduto(AlterarProdutoViewModel atualiza, int id, CancellationToken cancellationToken = default)
        {
            var query = await _consultarProdutoRepository.ConsultarAsync(cancellationToken);
            //// caso voce nao encontre o produto precisa garantir que o cliente receber um 404
            //// implementar um notification
            var produto = query.FirstOrDefault(x => x.Id == id);

            if (produto is null)
                return default;

            produto.Nome = atualiza.Nome;
            await _atualizarProdutoRepository.AtualizarAsync(produto, cancellationToken);
            return produto;
        }
    }
}
