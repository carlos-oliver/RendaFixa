using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto.ViewModels;
using System.Net;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto
{
    public interface IAlterarProdutoUseCase
    {
        Task<(HttpStatusCode, DefaultResultViewModel)> AlterarNomeProduto(AlterarProdutoViewModel atualiza, int id, CancellationToken cancellationToken);
    }
}
