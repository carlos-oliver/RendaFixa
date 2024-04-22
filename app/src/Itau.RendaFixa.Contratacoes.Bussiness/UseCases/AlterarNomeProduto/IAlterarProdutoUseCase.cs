using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto.ViewModels;
using Microsoft.AspNetCore.JsonPatch;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto
{
    public interface IAlterarProdutoUseCase
    {
        Task<AlterarProdutoViewModel> AlterarNomeProduto(JsonPatchDocument<AlterarProdutoViewModel> patch, int id, CancellationToken cancellationToken);
    }
}
