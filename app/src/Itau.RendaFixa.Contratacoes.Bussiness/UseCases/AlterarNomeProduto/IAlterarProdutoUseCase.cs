using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto.ViewModels;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto
{
    public interface IAlterarProdutoUseCase
    {
        Task<Produto?> AlterarNomeProduto(AlterarProdutoViewModel atualiza, int id, CancellationToken cancellationToken);
    }
}
