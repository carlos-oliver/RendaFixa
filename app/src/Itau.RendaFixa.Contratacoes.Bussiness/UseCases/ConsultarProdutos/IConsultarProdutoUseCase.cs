using Itau.RendaFixa.Contratacoes.Bussiness.Data.Dtos;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos
{
    public interface IConsultarProdutoUseCase
    {
        Task<ApiResponse<IEnumerable<ProdutosDto>>> ObterProdutoAsync(string nome, int take);
    }
}
