using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante.ViewModels;
using System.Web.Http.OData;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante
{
    public interface IHabilitarContratanteUseCase
    {
        Task<HabilitarContratanteViewModel> HabilitarContratante(Delta<HabilitarContratanteViewModel> correcao, string cpf, CancellationToken cancellation = default);
    }
}
