using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System.Web.Http.OData;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto
{
    public interface IAlterarProdutoUseCase
    {
        Task<AlterarProdutoViewModel> AlterarNomeProduto(Delta<AlterarProdutoViewModel> atualiza, int id, CancellationToken cancellationToken);
    }
}
