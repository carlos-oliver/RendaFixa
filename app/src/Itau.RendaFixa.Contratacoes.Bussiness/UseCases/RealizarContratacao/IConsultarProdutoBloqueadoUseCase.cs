namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao
{
    public interface IConsultarProdutoBloqueadoUseCase
    {
        Task<bool> ConsultarProduto(int id);
    }
}
