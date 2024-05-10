namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao
{
    public interface IProdutoPorSegmentoUseCase
    {
        Task<bool> ValidarProdutoPorSegmento(int idProduto, int idContratante, double valorUnitario, CancellationToken cancellationToken = default);
    }
}
