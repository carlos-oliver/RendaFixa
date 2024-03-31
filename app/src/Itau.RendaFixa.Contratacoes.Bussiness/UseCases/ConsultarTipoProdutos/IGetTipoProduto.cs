using Itau.RendaFixa.Contratacoes.Bussiness.Data.Dtos;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos
{
    public interface IGetTipoProduto
    {
        Task<ApiResponse<List<TipoProdutoDto>>> ExecuteAsync();
    }
}
