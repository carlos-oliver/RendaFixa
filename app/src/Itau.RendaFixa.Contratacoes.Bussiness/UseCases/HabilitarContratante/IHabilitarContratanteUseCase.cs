using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante.ViewModels;
using Microsoft.AspNetCore.JsonPatch;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante
{
    public interface IHabilitarContratanteUseCase
    {
        Task<HabilitarContratanteViewModel> HabilitarContratante(JsonPatchDocument<HabilitarContratanteViewModel> correcao, string cpf, CancellationToken cancellation = default);
    }
}
