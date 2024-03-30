using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos.ViewModels;


namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos
{
    public interface IConsultarProdutoUseCase
    {
        Task<ApiResponse<Produtos>> ObterProdutoAsync(string nome);
    }
}
