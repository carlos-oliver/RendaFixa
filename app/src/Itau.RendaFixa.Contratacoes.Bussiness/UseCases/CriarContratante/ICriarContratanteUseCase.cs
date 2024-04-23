using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante.ViewModels;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante
{
    public interface ICriarContratanteUseCase
    {
        Task<Contratante> CriarContratante(CriarContratanteViewModel criarContranteViewModel, CancellationToken cancellationToken = default);
    }
}
