namespace Itau.RendaFixa.Contratacoes.Api.ViewModels
{
    public interface IGetTipoProduto
    {
        Task<ApiResponse<List<TipoProduto>>> ExecuteAsync();
    }
}
